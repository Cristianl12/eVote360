using eVote360.Application.Services;
using eVote360.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eVote360.Web.Controllers
{
    public class EleccionController : Controller
    {
        private readonly EleccionService _service;

        public EleccionController(EleccionService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var elecciones = await _service.ObtenerTodasAsync();
            return View(elecciones);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Eleccion model)
        {
            if (ModelState.IsValid)
            {
                await _service.CrearAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}

