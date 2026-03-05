using eVote360.Domain.Base;
using System;
using System.Collections.Generic;

namespace eVote360.Domain.Entities
{
    public class Ciudadano : BaseEntity
    {
        public string Cedula { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; } = string.Empty;

        // Vinculación con usuario de Identity
        public string? IdentityUserId { get; set; }

        public ICollection<Voto>? Votos { get; set; }
    }
}



