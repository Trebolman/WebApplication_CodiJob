using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication_CodiJob.Model.CodiJobDb
{
    [Table("TProyectos")]
    public partial class Tproyectos
    {
        public Tproyectos()
        {
            TusuarioProyecto = new HashSet<TusuarioProyecto>();
        }

        [Key]
        public Guid ProyectoId { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(100)]
        public string Descripcion { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Fecha { get; set; }
        [StringLength(50)]
        public string Url { get; set; }

        [InverseProperty("Proyecto")]
        public ICollection<TusuarioProyecto> TusuarioProyecto { get; set; }
    }
}
