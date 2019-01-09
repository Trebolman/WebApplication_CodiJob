using System.Linq;

namespace Domain.IRepositories
{
    public interface IProyectoRepository: IRepository<TProyecto>
    {
        IQueryable<TProyecto> FilterProyectos(int pageSize, int page);
    }
}