using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using eVote360.Domain.Base;

namespace eVote360.Domain.Entities
{
    public class Puesto : BaseEntity
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        // Relaciones
        public ICollection<Candidato>? Candidatos { get; set; }
    }
}

