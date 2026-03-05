using eVote360.Application.Services;
using eVote360.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eVote360.Web.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class PartidoController : Controller
    {
        private readonly PartidoService _service;

        public PartidoController(PartidoService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var partidos = await _service.ObtenerTodosAsync();
            return View(partidos);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Partido model)
        {
            if (ModelState.IsValid)
            {
                await _service.CrearAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Eliminar(Guid id)
        {
            await _service.EliminarAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
