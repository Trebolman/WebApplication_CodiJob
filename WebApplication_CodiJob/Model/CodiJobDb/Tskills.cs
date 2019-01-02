using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication_CodiJob.Model.CodiJobDb
{
    [Table("TSkills")]
    public partial class Tskills
    {
        public Tskills()
        {
            TskillUsuario = new HashSet<TskillUsuario>();
        }

        [Key]
        public Guid SkillId { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }

        [InverseProperty("Skill")]
        public ICollection<TskillUsuario> TskillUsuario { get; set; }
    }
}
