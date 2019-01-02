using WebApplication_CodiJob.Model.CodiJobDb;
using System;
using System.Linq;
namespace CodiJobServices.Model.Repositories
{
    public class EFProyectoRepository : IProyectoRepository
    {
        public IQueryable<Tproyectos> Items => context.Tproyectos;
        private CodiJobDbContext context;
        public EFProyectoRepository(CodiJobDbContext ctx)
        {
            context = ctx;
        }
        public void Save(Tproyectos proyecto)
        {
            if (proyecto.ProyectoId == Guid.Empty)
            {
                proyecto.ProyectoId = Guid.NewGuid();
                context.Tproyectos.Add(proyecto);
            }
            else
            {
                Tproyectos dbEntry = context.Tproyectos
                .FirstOrDefault(p => p.ProyectoId == proyecto.ProyectoId);
                if (dbEntry != null)
                {
                    dbEntry.Nombre = proyecto.Nombre;
                    dbEntry.Descripcion = proyecto.Descripcion;
                    dbEntry.Fecha = proyecto.Fecha;
                    dbEntry.Url = proyecto.Url;

                }
            }
            context.SaveChangesAsync();
        }

        public void Delete(Guid ProyectoID)
        {
            Tproyectos dbEntry = context.Tproyectos
            .FirstOrDefault(p => p.ProyectoId == ProyectoID);
            if (dbEntry != null)
            {
                context.Tproyectos.Remove(dbEntry);
                context.SaveChanges();
            }
        }

        public IQueryable<Tproyectos> FilterProyectos(int pageSize, int page)
        {
            return this.Items
            .Skip((page - 1) * pageSize)
            .Take(pageSize);
        }
    }
}