using eVote360.Domain.Entities;
using eVote360.Domain.Repositories;

//using eVote360.Domain.Entities;

namespace eVote360.Application.Services
{
    public class VotoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Voto> _votoRepository;

        public VotoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _votoRepository = _unitOfWork.Repository<Voto>();
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



