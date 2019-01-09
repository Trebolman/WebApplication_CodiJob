using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IServices
{
    public interface IUsuarioPerfilService
    {
        void Insert(UsuarioPerfilDTO entityDTO);
        IList<UsuarioPerfilDTO> GetAll();
        void Update(UsuarioPerfilDTO entityDTO);
        void Delete(Guid entityId);
        UsuarioPerfilDTO GetUsuarioPerfil(Guid entityId);
    }
}
