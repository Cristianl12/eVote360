
using eVote360.Application.Services;
using eVote360.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eVote360.Web.Controllers
{
    public class CiudadanoController : Controller
    {
        private readonly CiudadanoService _service;

        public CiudadanoController(CiudadanoService service)
        {
            _service = service;
        }

        // 🔹 Listar todos
        public async Task<IActionResult> Index()
        {
            var ciudadanos = await _service.ObtenerTodosAsync();
            return View(ciudadanos);
        }

        // 🔹 Crear (GET)
        public IActionResult Crear()
        {
            return View();
        }

        // 🔹 Crear (POST)
        [HttpPost]
        public async Task<IActionResult> Crear(Ciudadano model)
        {
            if (ModelState.IsValid)
            {
                await _service.CrearAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // 🔹 Editar (GET)
        public async Task<IActionResult> Editar(Guid id)
        {
            var ciudadano = await _service.ObtenerPorIdAsync(id);
            if (ciudadano == null) return NotFound();
            return View(ciudadano);
        }

        // 🔹 Editar (POST)
        [HttpPost]
        public async Task<IActionResult> Editar(Ciudadano model)
        {
            if (ModelState.IsValid)
            {
                await _service.ActualizarAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // 🔹 Eliminar
        public async Task<IActionResult> Eliminar(Guid id)
        {
            await _service.EliminarAsync(id);
            return RedirectToAction("Index");
        }
    }
}

