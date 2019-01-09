
using System.Linq;

namespace Domain.IRepositories
{
    public interface IGrupoRepository:IRepository<TGrupo>
    {
        IQueryable<TGrupo> FilterGrupos(int pageSize, int page);
    }
}
