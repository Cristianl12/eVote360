using eVote360.Domain.Entities;
using eVote360.Domain.Repositories;

namespace eVote360.Application.Services
{
    public class CiudadanoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Ciudadano> _ciudadanoRepository;

        public CiudadanoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _ciudadanoRepository = _unitOfWork.Repository<Ciudadano>();
        }

        public async Task<IEnumerable<Ciudadano>> ObtenerTodosAsync()
        {
            return await _ciudadanoRepository.GetAllAsync();
        }

        public async Task<Ciudadano?> ObtenerPorIdAsync(Guid id)
        {
            return await _ciudadanoRepository.GetByIdAsync(id);
        }

        public async Task CrearAsync(Ciudadano ciudadano)
        {
            await _ciudadanoRepository.AddAsync(ciudadano);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Ciudadano ciudadano)
        {
            _ciudadanoRepository.Update(ciudadano);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarAsync(Guid id)
        {
            var ciudadano = await _ciudadanoRepository.GetByIdAsync(id);
            if (ciudadano != null)
            {
                _ciudadanoRepository.Delete(ciudadano);
                await _unitOfWork.SaveChangesAsync();
            }
        }
        public async Task<Ciudadano?> ObtenerPorIdentityUserIdAsync(string identityUserId)
        {
            var todos = await _unitOfWork.Repository<Ciudadano>().FindAsync(c => c.IdentityUserId == identityUserId);
            return todos.FirstOrDefault();
        }

    }
}

