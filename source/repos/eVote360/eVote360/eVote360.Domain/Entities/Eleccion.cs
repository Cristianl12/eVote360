using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using eVote360.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace eVote360.Domain.Entities
{
    public class Eleccion : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public DateTime Fecha { get; set; }

        public string? Descripcion { get; set; }
    }
}


