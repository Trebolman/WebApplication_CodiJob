using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class GrupoDTO
    {
        public Guid GrupoId { get; set; }
        public string GrupoNom { get; set; }
        public string GrupoFoto { get; set; }
        public string GrupoProm { get; set; }
    }
}
