using eVote360.Domain.Entities;
using eVote360.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVote360.Application.Services
{
    public class EleccionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Eleccion> _repo;

        public EleccionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repo = _unitOfWork.Repository<Eleccion>();
        }

        public async Task<IEnumerable<Eleccion>> ObtenerTodasAsync() => await _repo.GetAllAsync();

        public async Task CrearAsync(Eleccion eleccion)
        {
            await _repo.AddAsync(eleccion);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

