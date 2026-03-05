using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eVote360.Domain.Base;

namespace eVote360.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string NombreUsuario { get; set; } = string.Empty;
        public string ContrasenaHash { get; set; } = string.Empty;
        public string Rol { get; set; } = "Administrador";
    }
}

