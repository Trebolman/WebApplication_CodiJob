using Application.DTOs;
using Application.IServices;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.IRepositories;

namespace Application.Services
{
    public class UsuarioPerfilService : IUsuarioPerfilService
    {
        IUsuarioPerfilRepository repository;
        public UsuarioPerfilService(IUsuarioPerfilRepository repo)
        {
            repository = repo;
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }

        public IList<UsuarioPerfilDTO> GetAll()
        {
            IQueryable<TUsuarioperfil> gruposEntities = repository.Items;

            return Builders.
                   GenericBuilder.
                   builderListEntityDTO<UsuarioPerfilDTO, TUsuarioperfil>
                   (gruposEntities);
        }

        public UsuarioPerfilDTO GetUsuarioPerfil(Guid entityId)
        {
            var entities = repository.Items;
            var usuario = repository.Items.Where(user => user.UsuperId == entityId).FirstOrDefault();
            //foreach(var usuarioPerfil in entities)
            //{
            //    if (usuarioPerfil.UsuperId == entityId)
            //        return usuarioPerfil;
            //}
            return Builders.GenericBuilder.builderEntityDTO<UsuarioPerfilDTO, TUsuarioperfil>(usuario);
        }

        public void Insert(UsuarioPerfilDTO entityDTO)
        {
            TUsuarioperfil entity = Builders.
                        GenericBuilder.
                        builderDTOEntity<TUsuarioperfil, UsuarioPerfilDTO>
                        (entityDTO);
            repository.Save(entity);
        }


        public void Update(UsuarioPerfilDTO entityDTO)
        {
            var entity = Builders.
                GenericBuilder.
                builderDTOEntity<TUsuarioperfil, UsuarioPerfilDTO>
                (entityDTO);
            repository.Save(entity);
        }

    }
}
