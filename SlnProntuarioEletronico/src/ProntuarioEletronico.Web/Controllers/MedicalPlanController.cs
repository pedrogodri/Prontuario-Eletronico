using Microsoft.AspNetCore.Mvc;
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
    }
}
