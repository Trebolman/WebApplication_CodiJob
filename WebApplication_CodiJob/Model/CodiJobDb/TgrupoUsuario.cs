using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication_CodiJob.Model.CodiJobDb
{
    [Table("TGrupo_Usuario")]
    public partial class TgrupoUsuario
    {
        public Guid UsuarioId { get; set; }
        public Guid GrupoId { get; set; }

        [ForeignKey("GrupoId")]
        [InverseProperty("TgrupoUsuario")]
        public Tgrupos Grupo { get; set; }
        [ForeignKey("UsuarioId")]
        [InverseProperty("TgrupoUsuario")]
        public TusuarioPerfil Usuario { get; set; }
    }
}
