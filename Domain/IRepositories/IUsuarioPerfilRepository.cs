

using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IUsuarioPerfilRepository : IRepository<TUsuarioperfil>
    {
        Task SaveWithId(TUsuarioperfil entity);
    }
}
