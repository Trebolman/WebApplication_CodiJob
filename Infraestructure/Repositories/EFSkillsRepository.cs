
using Domain;
using Domain.IRepositories;
using Infraestructure.Persistencia;
using System;
using System.Linq;

namespace Infraestructure.Repositories
{
    public class EFSkillsRepository : ISkillRepository
    {
        public IQueryable<TSkill> Items => context.TSkill;
        private CodiJobDbContext context;
        public EFSkillsRepository(CodiJobDbContext ctx)
        {
            context = ctx;
        }
        public void Save(TSkill skill)
        {
            if (skill.SkillId == Guid.Empty)
            {
                skill.SkillId = Guid.NewGuid();
                context.TSkill.Add(skill);
            }
            else
            {
                TSkill dbEntry = context.TSkill
                .FirstOrDefault(s => s.SkillId == skill.SkillId);
                if (dbEntry != null)
                {
                    dbEntry.SkillNom = skill.SkillNom;

                }
            }
            context.SaveChangesAsync();
        }

        public void Delete(Guid SkillID)
        {
            TSkill dbEntry = context.TSkill
            .FirstOrDefault(s => s.SkillId == SkillID);
            if (dbEntry != null)
            {
                context.TSkill.Remove(dbEntry);
                context.SaveChanges();
            }
        }

        //public IQueryable<Tskills> FilterProyectos(int pageSize, int page)
        //{
        //    return this.Items
        //    .Skip((page - 1) * pageSize)
        //    .Take(pageSize);
        //}
    }
}