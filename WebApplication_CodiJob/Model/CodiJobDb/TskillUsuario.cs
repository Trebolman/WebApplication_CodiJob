using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication_CodiJob.Model.CodiJobDb
{
    [Table("TSkill_Usuario")]
    public partial class TskillUsuario
    {
        public Guid UsuarioId { get; set; }
        public Guid SkillId { get; set; }
        [StringLength(50)]
        public string Nivel { get; set; }
        public bool? Verificado { get; set; }

        [ForeignKey("SkillId")]
        [InverseProperty("TskillUsuario")]
        public Tskills Skill { get; set; }
        [ForeignKey("UsuarioId")]
        [InverseProperty("TskillUsuario")]
        public TusuarioPerfil Usuario { get; set; }
    }
}
