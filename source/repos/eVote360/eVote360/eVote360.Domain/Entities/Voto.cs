using eVote360.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eVote360.Domain.Entities
{
    public class Voto : BaseEntity
    {
        [Required]
        public Guid CiudadanoId { get; set; }

        [Required]
        public Guid CandidatoId { get; set; }

        [Required]
        public Guid EleccionId { get; set; }

        [ForeignKey("CiudadanoId")]
        public Ciudadano? Ciudadano { get; set; }

        [ForeignKey("CandidatoId")]
        public Candidato? Candidato { get; set; }

        [ForeignKey("EleccionId")]
        public Eleccion? Eleccion { get; set; }

        public DateTime FechaVoto { get; set; } = DateTime.Now;
    }
}


