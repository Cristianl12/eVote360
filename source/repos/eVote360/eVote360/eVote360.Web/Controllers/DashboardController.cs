using eVote360.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eVote360.Web.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class DashboardController : Controller
    {
        private readonly CiudadanoService _ciudadanoService;
        private readonly CandidatoService _candidatoService;
        private readonly EleccionService _eleccionService;
        private readonly VotoService _votoService;
        private readonly ResultadoService _resultadoService;

        public DashboardController(
            CiudadanoService ciudadanoService,
            CandidatoService candidatoService,
            EleccionService eleccionService,
            VotoService votoService,
            ResultadoService resultadoService)
        {
            _ciudadanoService = ciudadanoService;
            _candidatoService = candidatoService;
            _eleccionService = eleccionService;
            _votoService = votoService;
            _resultadoService = resultadoService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TotalCiudadanos = (await _ciudadanoService.ObtenerTodosAsync()).Count();
            ViewBag.TotalCandidatos = (await _candidatoService.ObtenerTodosAsync()).Count();
            ViewBag.TotalElecciones = (await _eleccionService.ObtenerTodasAsync()).Count();
            ViewBag.TotalVotos = (await _votoService.ObtenerTodosAsync()).Count();
            ViewBag.Resultados = await _resultadoService.ObtenerResultadosAsync();

            return View();
        }
    }
}

