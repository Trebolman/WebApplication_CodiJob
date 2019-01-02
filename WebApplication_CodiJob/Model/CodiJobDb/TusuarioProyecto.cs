using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication_CodiJob.Model.CodiJobDb
{
    [Table("TUsuarioProyecto")]
    public partial class TusuarioProyecto
    {
        public Guid UsuarioId { get; set; }
        public Guid ProyectoId { get; set; }

        [ForeignKey("ProyectoId")]
        [InverseProperty("TusuarioProyecto")]
        public Tproyectos Proyecto { get; set; }
        [ForeignKey("UsuarioId")]
        [InverseProperty("TusuarioProyecto")]
        public TusuarioPerfil Usuario { get; set; }
    }
}
