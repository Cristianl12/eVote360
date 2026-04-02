using eVote360.Domain.Entities;
using eVote360.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVote360.Application.Services
{
    public class PuestoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Puesto> _repo;

        public PuestoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repo = _unitOfWork.Repository<Puesto>();
        }

        public async Task<IEnumerable<Puesto>> ObtenerTodosAsync() => await _repo.GetAllAsync();

        public async Task<Puesto?> ObtenerPorIdAsync(Guid id) => await _repo.GetByIdAsync(id);

        public async Task CrearAsync(Puesto puesto)
        {
            await _repo.AddAsync(puesto);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Puesto puesto)
        {
            _repo.Update(puesto);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarAsync(Guid id)
        {
            var puesto = await _repo.GetByIdAsync(id);
            if (puesto != null)
            {
                _repo.Delete(puesto);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
