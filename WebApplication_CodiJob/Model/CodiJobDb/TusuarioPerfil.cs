using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication_CodiJob.Model.CodiJobDb
{
    [Table("TUsuario_Perfil")]
    public partial class TusuarioPerfil
    {
        public TusuarioPerfil()
        {
            TgrupoUsuario = new HashSet<TgrupoUsuario>();
            TskillUsuario = new HashSet<TskillUsuario>();
            TusuarioProyecto = new HashSet<TusuarioProyecto>();
        }

        [Key]
        public Guid UsuarioId { get; set; }
        [StringLength(100)]
        public string Descripcion { get; set; }
        [StringLength(100)]
        public string Git { get; set; }
        [StringLength(50)]
        public string Blog { get; set; }
        [StringLength(50)]
        public string WebSite { get; set; }

        [InverseProperty("Usuario")]
        public ICollection<TgrupoUsuario> TgrupoUsuario { get; set; }
        [InverseProperty("Usuario")]
        public ICollection<TskillUsuario> TskillUsuario { get; set; }
        [InverseProperty("Usuario")]
        public ICollection<TusuarioProyecto> TusuarioProyecto { get; set; }
    }
}
