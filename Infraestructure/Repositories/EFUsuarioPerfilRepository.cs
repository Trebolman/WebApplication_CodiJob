using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.IRepositories;
using Infraestructure.Persistencia;

namespace Infraestructure.Repositories
{
    public class EFUsuarioPerfilRepository : IUsuarioPerfilRepository
    {
        CodiJobDbContext Context;
        public EFUsuarioPerfilRepository(CodiJobDbContext ctx)
        {
            this.Context = ctx;
        }

        public IQueryable<TUsuarioperfil> Items => Context.TUsuarioperfil;

        public void Delete(Guid itemId)
        {
            TUsuarioperfil dbEntry = Context.TUsuarioperfil
                .FirstOrDefault(p => p.UsuperId == itemId);

            if (dbEntry != null)
            {
                Context.TUsuarioperfil.Remove(dbEntry);
                Context.SaveChanges();
            }
        }

        public void Save(TUsuarioperfil item)
        {
            if (item.UsuperId == Guid.Empty)
            {
                item.UsuperId = Guid.NewGuid();
                Context.TUsuarioperfil.Add(item);
            }
            else
            {
                TUsuarioperfil dbEntry = Context.TUsuarioperfil
                .FirstOrDefault(p => p.UsuperId == item.UsuperId);
                if (dbEntry != null)
                {
                    dbEntry.UsuperDesc = item.UsuperDesc;
                    dbEntry.UsuperGit = item.UsuperGit;
                    dbEntry.UsuperBlog = item.UsuperBlog;
                    dbEntry.UsuperWeb = item.UsuperWeb;

                }
            }
            Context.SaveChangesAsync();
        }
    }
}
