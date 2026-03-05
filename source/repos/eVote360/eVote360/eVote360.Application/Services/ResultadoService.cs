using eVote360.Application.ViewModels;
using eVote360.Domain.Entities;
using eVote360.Domain.Repositories;

namespace eVote360.Application.Services
{
    public class ResultadoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Voto> _votoRepository;
        private readonly IBaseRepository<Candidato> _candidatoRepository;
        private readonly IBaseRepository<Eleccion> _eleccionRepository;

        public ResultadoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _votoRepository = _unitOfWork.Repository<Voto>();
            _candidatoRepository = _unitOfWork.Repository<Candidato>();
            _eleccionRepository = _unitOfWork.Repository<Eleccion>();
        }

        public async Task<IEnumerable<ResultadoViewModel>> ObtenerResultadosAsync()
        {
            var votos = await _votoRepository.GetAllAsync();
            var candidatos = await _candidatoRepository.GetAllAsync();
            var elecciones = await _eleccionRepository.GetAllAsync();

            var resultados = votos
                .GroupBy(v => new { v.CandidatoId, v.EleccionId })
                .Select(g =>
                {
                    var candidato = candidatos.FirstOrDefault(c => c.Id == g.Key.CandidatoId);
                    var eleccion = elecciones.FirstOrDefault(e => e.Id == g.Key.EleccionId);

                    return new ResultadoViewModel
                    {
                        Candidato = candidato?.NombreCompleto ?? "Desconocido",
                        Eleccion = eleccion?.Nombre ?? "Sin elección",
                        CantidadVotos = g.Count()
                    };
                })
                .OrderByDescending(r => r.CantidadVotos)
                .ToList();

            return resultados;
        }
    }
}

