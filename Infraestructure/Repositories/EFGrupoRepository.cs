
using Domain;
using Domain.IRepositories;
using Infraestructure.Persistencia;
using System;
using System.Linq;

namespace Infraestructure.Repositories
{
    public class EFGrupoRepository:IGrupoRepository
    {
        public IQueryable<TGrupo> Items => context.TGrupo;
        private CodiJobDbContext context;
        public EFGrupoRepository(CodiJobDbContext ctx)
        {
            context = ctx;
        }
        public void Save(TGrupo grupo)
        {
            if (grupo.GrupoId == Guid.Empty)
            {
                grupo.GrupoId = Guid.NewGuid();
                context.TGrupo.Add(grupo);
            }
            else
            {
                TGrupo dbEntry = context.TGrupo
                .FirstOrDefault(g => g.GrupoId == grupo.GrupoId);
                if (dbEntry != null)
                {
                    dbEntry.GrupoNom = grupo.GrupoNom;
                    dbEntry.GrupoFoto = grupo.GrupoFoto;
                    dbEntry.GrupoProm = grupo.GrupoProm;

                }
            }
            context.SaveChangesAsync();
        }

        public void Delete(Guid GrupoID)
        {
            TGrupo dbEntry = context.TGrupo
            .FirstOrDefault(g => g.GrupoId == GrupoID);
            if (dbEntry != null)
            {
                context.TGrupo.Remove(dbEntry);
                context.SaveChanges();
            }
        }

        public IQueryable<TGrupo> FilterGrupos(int pageSize, int page)
        {
            return this.Items
            .Skip((page - 1) * pageSize)
            .Take(pageSize);
        }
    }
}
