using eVote360.Domain.Entities;
using eVote360.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using eVote360.Domain.Entities;

namespace eVote360.Application.Services
{
    public class CandidatoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Candidato> _repo;

        public CandidatoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repo = _unitOfWork.Repository<Candidato>();
        }

        public async Task<IEnumerable<Candidato>> ObtenerTodosAsync() => await _repo.GetAllAsync();

        public async Task CrearAsync(Candidato candidato)
        {
            await _repo.AddAsync(candidato);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

