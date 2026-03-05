using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using eVote360.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eVote360.Domain.Entities
{
    public class Candidato : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string NombreCompleto { get; set; } = string.Empty;

        [Required]
        public string Cargo { get; set; } = string.Empty;

        [Required] // aplica directamente al campo FK
        [ForeignKey(nameof(PartidoId))]
        public Guid PartidoId { get; set; }

        public Partido? Partido { get; set; }


    }
}


