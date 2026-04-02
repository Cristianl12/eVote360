using eVote360.Application.Services;
using eVote360.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eVote360.Web.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class SeedDataController : Controller
    {
        private readonly PartidoService _partidoService;
        private readonly PuestoService _puestoService;
        private readonly CandidatoService _candidatoService;
        private readonly EleccionService _eleccionService;
        private readonly CiudadanoService _ciudadanoService;

        public SeedDataController(
            PartidoService partidoService,
            PuestoService puestoService,
            CandidatoService candidatoService,
            EleccionService eleccionService,
            CiudadanoService ciudadanoService)
        {
            _partidoService = partidoService;
            _puestoService = puestoService;
            _candidatoService = candidatoService;
            _eleccionService = eleccionService;
            _ciudadanoService = ciudadanoService;
        }

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> PopulateTestData()
        {
            try
            {
                // 1. Crear Puestos
                var presidencia = new Puesto { Nombre = "Presidente", Descripcion = "Jefe de estado y gobierno" };
                await _puestoService.CrearAsync(presidencia);

                var vicepresidencia = new Puesto { Nombre = "Vicepresidente", Descripcion = "Suplente del presidente" };
                await _puestoService.CrearAsync(vicepresidencia);

                // 2. Crear Partidos
                var partidoRojo = new Partido { Nombre = "Partido Rojo", Siglas = "PR", LogoUrl = "https://via.placeholder.com/100/FF0000/FFFFFF?text=PR" };
                await _partidoService.CrearAsync(partidoRojo);

                var partidoAzul = new Partido { Nombre = "Partido Azul", Siglas = "PB", LogoUrl = "https://via.placeholder.com/100/0000FF/FFFFFF?text=PB" };
                await _partidoService.CrearAsync(partidoAzul);

                var partidoVerde = new Partido { Nombre = "Partido Verde", Siglas = "PV", LogoUrl = "https://via.placeholder.com/100/00AA00/FFFFFF?text=PV" };
                await _partidoService.CrearAsync(partidoVerde);

                // Refrescar partidos para obtener IDs
                var partidos = (await _partidoService.ObtenerTodosAsync()).ToList();
                var puestos = (await _puestoService.ObtenerTodosAsync()).ToList();

                // 3. Crear Candidatos
                var candidatos = new List<Candidato>
                {
                    new Candidato { NombreCompleto = "Juan García Rodríguez", Cargo = "Candidato a Presidente", PartidoId = partidos[0].Id, PuestoId = puestos[0].Id },
                    new Candidato { NombreCompleto = "María López Martínez", Cargo = "Candidata a Presidenta", PartidoId = partidos[1].Id, PuestoId = puestos[0].Id },
                    new Candidato { NombreCompleto = "Carlos Fernández Pérez", Cargo = "Candidato a Presidente", PartidoId = partidos[2].Id, PuestoId = puestos[0].Id },
                    new Candidato { NombreCompleto = "Pedro González Sánchez", Cargo = "Candidato a Vicepresidente", PartidoId = partidos[0].Id, PuestoId = puestos[1].Id },
                    new Candidato { NombreCompleto = "Ana Rodríguez López", Cargo = "Candidata a Vicepresidenta", PartidoId = partidos[1].Id, PuestoId = puestos[1].Id }
                };

                foreach (var candidato in candidatos)
                {
                    await _candidatoService.CrearAsync(candidato);
                }

                // 4. Crear Elección
                var eleccion = new Eleccion
                {
                    Nombre = "Elecciones Generales 2026",
                    Descripcion = "Elecciones presidenciales y vicepresidenciales del año 2026",
                    Fecha = DateTime.Now.AddDays(7)
                };
                await _eleccionService.CrearAsync(eleccion);

                // 5. Crear Ciudadanos
                var ciudadanos = new List<Ciudadano>
                {
                    new Ciudadano { NombreCompleto = "Isabella García Ruiz", Cedula = "12345678", FechaNacimiento = new DateTime(1985, 5, 15), Direccion = "Calle Principal 123" },
                    new Ciudadano { NombreCompleto = "Roberto Martínez López", Cedula = "23456789", FechaNacimiento = new DateTime(1990, 3, 22), Direccion = "Avenida Central 456" },
                    new Ciudadano { NombreCompleto = "Sofía Pérez Gómez", Cedula = "34567890", FechaNacimiento = new DateTime(1988, 7, 10), Direccion = "Calle Secundaria 789" },
                    new Ciudadano { NombreCompleto = "Miguel Sánchez Rodríguez", Cedula = "45678901", FechaNacimiento = new DateTime(1992, 11, 5), Direccion = "Boulevard Paseo 321" },
                    new Ciudadano { NombreCompleto = "Elena Romero García", Cedula = "56789012", FechaNacimiento = new DateTime(1987, 2, 14), Direccion = "Plaza Mayor 555" }
                };

                foreach (var ciudadano in ciudadanos)
                {
                    await _ciudadanoService.CrearAsync(ciudadano);
                }

                return Ok(new
                {
                    success = true,
                    message = "Datos de prueba creados exitosamente",
                    data = new
                    {
                        partidos = partidos.Count,
                        puestos = puestos.Count,
                        candidatos = candidatos.Count,
                        elecciones = 1,
                        ciudadanos = ciudadanos.Count
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}
