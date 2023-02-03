using Microsoft.AspNetCore.Mvc;
using ProntuarioEletronico.Domain.DTO;
using ProntuarioEletronico.Domain.IServices;

namespace ProntuarioEletronico.Web.Controllers
{
    public class MedicalPlanController : Controller
    {
        private readonly IMedicalPlanService _service;

        public MedicalPlanController(IMedicalPlanService service)
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
        public async Task<IActionResult> Create([Bind("id, plan")] MedicalPlanDTO medicalPlan)
        {
            if(ModelState.IsValid) 
            { 
                if(await _service.Save(medicalPlan) > 0) return RedirectToAction(nameof(Index));           
            }   
            return View(medicalPlan);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null) return NotFound();

            var medicalPlan = await _service.FindById(id);
            return View(medicalPlan);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, [Bind("id, plan")] MedicalPlanDTO medicalPlan)
        {
            if(!(id == medicalPlan.id)) return NotFound();

            if (ModelState.IsValid)
            {
                if(await _service.Save(medicalPlan) > 0) return RedirectToAction(nameof(Index));
            }
            return View(medicalPlan);
        }
    }
}
