using Microsoft.AspNetCore.Mvc;
using ProntuarioEletronico.Domain.DTO;
using ProntuarioEletronico.Domain.IRepositories;
using ProntuarioEletronico.Domain.IServices;
using ProntuarioEletronico.Web.Models;
using ProntuarioEletronico.Web.Models.DTO;

namespace ProntuarioEletronico.Web.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _service;

        public DoctorController(IDoctorService service)
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

        [HttpPost]
        public async Task<IActionResult> Create([Bind("id, crm, especialidade, description, name, age, email, phone, sex, maritalStatus, cpf, rg, dataCadastro")] DoctorDTO doctor)
        {
            if(ModelState.IsValid)
            {
                if(await _service.Save(doctor) > 0) return RedirectToAction("Index");
            }
            return View(doctor);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var doctor = await _service.FindById(id);
            return View(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, [Bind("id, crm, especialidade, description, name, age, email, phone, sex, maritalStatus, cpf, rg, dataCadastro, dataAtualizacao")] DoctorDTO doctor)
        {
            if (id != doctor.id) return NotFound();

            if (ModelState.IsValid)
            {
                if(await _service.Save(doctor) > 0) return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            var retDel = new ReturnJsonDel
            {
                status = "Success",
                code = "200"
            };
            if(await _service .Delete(id ?? 0) <= 0)
            {
                retDel = new ReturnJsonDel
                {
                    status = "Error",
                    code = "400"
                };
            }
            return View(retDel);
        }

        public IActionResult ImagePost(int id) 
        {
            ImageField doctorModel = new ImageField();
            if(id != 0)
            {
                doctorModel.IdImageField = id;
            }
            return View(doctorModel);
        }

        [HttpPost]
        public async Task<IActionResult> ImagePost(int idImage, List<IFormFile> imageDoctor)
        {
            try
            {
                if (idImage == 0)
                {
                    ViewBag.Message = $"O ID do Doutor é null!";
                    return View(new ImageField() { IdImageField = idImage });
                }

                var file = imageDoctor.FirstOrDefault();
                var fileName = $"{idImage}_{file.FileName}";
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//Upload", fileName);

                if(await _service.SaveFile(idImage, fileName) > 0)
                {
                    var stream = new FileStream(path, FileMode.Create);
                    await file.CopyToAsync(stream);
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
