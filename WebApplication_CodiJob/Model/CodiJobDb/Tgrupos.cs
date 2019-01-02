using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication_CodiJob.Model.CodiJobDb
{
    [Table("TGrupos")]
    public partial class Tgrupos
    {
        public Tgrupos()
        {
            TgrupoUsuario = new HashSet<TgrupoUsuario>();
        }

        [Key]
        public Guid GrupoId { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(100)]
        public string Foto { get; set; }
        [StringLength(50)]
        public string Promocion { get; set; }

        [InverseProperty("Grupo")]
        public ICollection<TgrupoUsuario> TgrupoUsuario { get; set; }
    }
}
