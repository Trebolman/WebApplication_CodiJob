using Application.DTOs;
using System.Threading.Tasks;

namespace Infraestructure.Transversal.Authentication
{
    public interface IUserService
    {
        Task<UsuarioPerfilDTO> AuthenticateAsync(string username, string password);
    }
}
