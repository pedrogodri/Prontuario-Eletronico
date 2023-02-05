using Microsoft.AspNetCore.Mvc;
using ProntuarioEletronico.Domain.DTO;
using ProntuarioEletronico.Domain.IRepositories;
using ProntuarioEletronico.Domain.IServices;
using ProntuarioEletronico.Web.Models;
using ProntuarioEletronico.Web.Models.DTO;

namespace ProntuarioEletronico.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _service;

        public PatientController(IPatientService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(_service.FindAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        //medicalPlanId, plan, doctorId, doctor,

        [HttpPost]
        public async Task<IActionResult> Create([Bind("id, name, age, email, phone, sex, maritalStatus, cpf, rg, dataCadastro, " +
                                                      "profession, diagnosis, cep, address, number, complement")] PatientDTO patient)
        {
            if (ModelState.IsValid)
            {
                if (await _service.Save(patient) > 0) return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var patient = await _service.FindById(id);
            return View(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, [Bind("id, name, age, email, phone, sex, maritalStatus, cpf, rg, profession, " +
                                                             "diagnosis, cep, address, number, complement, dataAtualizacao")] PatientDTO patient)
        {
            if (id != patient.id) return NotFound();
            
            if (ModelState.IsValid) 
            {
                if(await _service.Save(patient) > 0) return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int? id)
        {
            var retDel = new ReturnJsonDel
            {
                status = "Success",
                code = "200"
            };
            if(await _service.Delete(id ?? 0) <= 0)
            {
                retDel = new ReturnJsonDel
                {
                    status = "Error",
                    code = "400"
                };
            }
            return Json(retDel);
        }

        public IActionResult ImagePost(int id)
        {
            ImageField patientModel = new ImageField();
            if(id != 0)
            {
                patientModel.IdImageField = id;
            }
            return View(patientModel);
        }

        [HttpPost]
        public async Task<IActionResult> ImagePost(int idImage, List<IFormFile> imagePatient)
        {
            try
            {
                if(idImage == 0)
                {
                    ViewBag.Message = $"O id do paciente é nulo";
                    return View(new ImageField() { IdImageField = idImage });
                }

                var file = imagePatient.FirstOrDefault();
                var fileName = $"{idImage}_{file.FileName}";
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//Upload", fileName);

                if(await _service.SaveFile(idImage, fileName) > 0)
                {
                    var stream = new FileStream(path, FileMode.Create);
                    file.CopyToAsync(stream);
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Message = $"Não foi possível salvar o arquivo: {path}";
                return View(new ImageField() { IdImageField = idImage, Image = fileName});
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error: {ex.Message}";
            }
            return View();
        }
    }
}
