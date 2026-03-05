using eVote360.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eVote360.Web.Controllers
{
    [Authorize(Roles = "Administrador,Dirigente")]
    public class ResultadoController : Controller
    {
        private readonly ResultadoService _service;

        public ResultadoController(ResultadoService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var resultados = await _service.ObtenerResultadosAsync();
            return View(resultados);
        }
    }
}

