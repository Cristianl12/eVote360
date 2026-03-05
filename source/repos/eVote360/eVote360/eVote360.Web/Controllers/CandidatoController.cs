using eVote360.Application.Services;
using eVote360.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eVote360.Web.Controllers
{
    public class CandidatoController : Controller
    {
        private readonly CandidatoService _service;
        private readonly PartidoService _partidoService;

        public CandidatoController(CandidatoService service, PartidoService partidoService)
        {
            _service = service;
            _partidoService = partidoService;
        }

        // GET: Index
        public async Task<IActionResult> Index()
        {
            var candidatos = await _service.ObtenerTodosAsync();
            return View(candidatos);
        }

        // GET: Crear
        public async Task<IActionResult> Crear()
        {
            ViewBag.Partidos = await _partidoService.ObtenerTodosAsync();
            return View();
        }

        // POST: Crear
        [HttpPost]
        public async Task<IActionResult> Crear(Candidato model)
        {
            var partido = (await _partidoService.ObtenerTodosAsync())
                          .FirstOrDefault(p => p.Id == model.PartidoId);

            if (partido == null)
                ModelState.AddModelError("PartidoId", "Debe seleccionar un partido válido.");

            var existentes = await _service.ObtenerTodosAsync();
            if (existentes.Any(c => c.NombreCompleto == model.NombreCompleto && c.PartidoId == model.PartidoId))
                ModelState.AddModelError("", "Este candidato ya existe en el partido seleccionado.");

            if (!ModelState.IsValid)
            {
                ViewBag.Partidos = await _partidoService.ObtenerTodosAsync();
                return View(model);
            }

            await _service.CrearAsync(model);
            return RedirectToAction(nameof(Index));
        }
    }
}





      