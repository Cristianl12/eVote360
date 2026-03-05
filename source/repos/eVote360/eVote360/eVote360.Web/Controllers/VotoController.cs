


using eVote360.Application.Services;
using eVote360.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace eVote360.Web.Controllers
{
    public class VotoController : Controller
    {
        private readonly VotoService _votoService;
        private readonly CandidatoService _candidatoService;
        private readonly EleccionService _eleccionService;
        private readonly CiudadanoService _ciudadanoService;
        private readonly UserManager<IdentityUser> _userManager;

        public VotoController(
            VotoService votoService,
            CandidatoService candidatoService,
            EleccionService eleccionService,
            CiudadanoService ciudadanoService,
            UserManager<IdentityUser> userManager)
        {
            _votoService = votoService;
            _candidatoService = candidatoService;
            _eleccionService = eleccionService;
            _ciudadanoService = ciudadanoService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var votos = await _votoService.ObtenerTodosAsync();
            return View(votos);
        }

        public async Task<IActionResult> Crear()
        {
            ViewBag.Candidatos = await _candidatoService.ObtenerTodosAsync();
            ViewBag.Elecciones = await _eleccionService.ObtenerTodasAsync();

            var userId = _userManager.GetUserId(User);
            if (!string.IsNullOrEmpty(userId))
            {
                var ciudadano = await _ciudadanoService.ObtenerPorIdentityUserIdAsync(userId);
                if (ciudadano != null)
                {
                    ViewBag.CiudadanoNombre = ciudadano.NombreCompleto + " - " + ciudadano.Cedula;
                }
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Voto model)
        {
            var userId = _userManager.GetUserId(User);
            if (string.IsNullOrEmpty(userId))
                return Forbid();

            var ciudadano = await _ciudadanoService.ObtenerPorIdentityUserIdAsync(userId);
            if (ciudadano == null)
            {
                TempData["Error"] = "Debe crear su perfil de ciudadano antes de votar.";
                return RedirectToAction("Crear", "Ciudadano");
            }

            model.CiudadanoId = ciudadano.Id;

            try
            {
                await _votoService.RegistrarVotoAsync(model);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error al registrar el voto.");
            }

            ViewBag.Candidatos = await _candidatoService.ObtenerTodosAsync();
            ViewBag.Elecciones = await _eleccionService.ObtenerTodasAsync();
            return View(model);
        }
    }
}

