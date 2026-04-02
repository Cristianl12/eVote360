using eVote360.Domain.Entities;
using eVote360.Domain.Repositories;

namespace eVote360.Application.Services
{
    /// <summary>
    /// Servicio encargado de gestionar las operaciones CRUD de votos en el sistema eVote360.
    /// Incluye validaciones de negocio para garantizar la integridad del proceso electoral.
    /// </summary>
    public class VotoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Voto> _votoRepository;

        public VotoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _votoRepository = _unitOfWork.Repository<Voto>();
        }

        /// <summary>
        /// Crea y registra un nuevo voto en el sistema.
        /// Valida que el ciudadano no haya votado previamente en la misma elección.
        /// </summary>
        /// <param name="voto">Entidad Voto con los datos del voto a registrar.</param>
        /// <returns>El voto creado con su identificador asignado.</returns>
        /// <exception cref="InvalidOperationException">Si el ciudadano ya votó en esta elección.</exception>
        public async Task<Voto> CrearVotoAsync(Voto voto)
        {
            // LOG: Inicio del proceso de creación de voto
            Console.WriteLine($"[VotoService] Iniciando creación de voto - CiudadanoId: {voto.CiudadanoId}, EleccionId: {voto.EleccionId}");

            // Validación de negocio: un ciudadano solo puede votar una vez por elección
            var votosExistentes = await _votoRepository.FindAsync(v =>
                v.CiudadanoId == voto.CiudadanoId && v.EleccionId == voto.EleccionId);

            if (votosExistentes.Any())
            {
                Console.WriteLine($"[VotoService] ERROR: Voto duplicado detectado para CiudadanoId: {voto.CiudadanoId}");
                throw new InvalidOperationException("Este ciudadano ya ha votado en esta elección.");
            }

            await _votoRepository.AddAsync(voto);
            await _unitOfWork.SaveChangesAsync();

            Console.WriteLine($"[VotoService] Voto creado exitosamente - VotoId: {voto.Id}");
            return voto;
        }

        public async Task RegistrarVotoAsync(Voto voto)
        {
            // Validación: un voto por ciudadano por elección
            var votosExistentes = await _votoRepository.FindAsync(v =>
                v.CiudadanoId == voto.CiudadanoId && v.EleccionId == voto.EleccionId);

            if (votosExistentes.Any())
            {
                throw new InvalidOperationException("Este ciudadano ya ha votado en esta elección.");
            }

            await _votoRepository.AddAsync(voto);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Voto>> ObtenerTodosAsync()
        {
            return await _votoRepository.GetAllAsync();
        }
    }
}



