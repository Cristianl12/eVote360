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

        /// <summary>
        /// Obtiene todas las elecciones y registra el evento en el sistema.
        /// </summary>
        public async Task<IEnumerable<Eleccion>> ObtenerTodasConLogAsync()
        {
            Console.WriteLine("[EleccionService] Consultando la lista de todas las elecciones disponibles en el sistema.");
            var elecciones = await _repo.GetAllAsync();
            Console.WriteLine($"[EleccionService] Se encontraron {elecciones.Count()} elecciones.");
            return elecciones;
        }

        public async Task CrearAsync(Eleccion eleccion)
        {
            await _repo.AddAsync(eleccion);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
