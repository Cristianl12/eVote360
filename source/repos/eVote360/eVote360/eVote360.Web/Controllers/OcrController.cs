using eVote360.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eVote360.Web.Controllers
{
    [Authorize(Roles = "Administrador,Dirigente")]
    public class OcrController : Controller
    {
        private readonly OcrService _ocrService;

        public OcrController(OcrService ocrService)
        {
            _ocrService = ocrService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile imagen)
        {
            if (imagen == null || imagen.Length == 0)
            {
                ViewBag.Error = "Debe seleccionar una imagen.";
                return View();
            }

            using var stream = imagen.OpenReadStream();
            var texto = await _ocrService.LeerTextoAsync(stream);
            ViewBag.TextoLeido = texto ?? "No se detectó texto en la imagen.";

            return View();
        }
    }
}

