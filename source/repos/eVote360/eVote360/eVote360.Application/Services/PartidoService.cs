using eVote360.Domain.Entities;
using eVote360.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVote360.Application.Services
{
    public class PartidoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Partido> _partidoRepository;

        public PartidoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _partidoRepository = _unitOfWork.Repository<Partido>();
        }

        public async Task<IEnumerable<Partido>> ObtenerTodosAsync() => await _partidoRepository.GetAllAsync();

        public async Task CrearAsync(Partido partido)
        {
            await _partidoRepository.AddAsync(partido);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarAsync(Guid id)
        {
            var partido = await _partidoRepository.GetByIdAsync(id);
            if (partido != null)
            {
                _partidoRepository.Delete(partido);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}

