using Microsoft.AspNetCore.Mvc;
using ProntuarioEletronico.Domain.IRepositories;
using ProntuarioEletronico.Domain.IServices;

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
    }
}
