using Microsoft.AspNetCore.Mvc;
using ProntuarioEletronico.Domain.IRepositories;
using ProntuarioEletronico.Domain.IServices;

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
    }
}
