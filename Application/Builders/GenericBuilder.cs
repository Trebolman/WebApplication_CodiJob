using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Builders
{
    public class GenericBuilder
    {
        //Convertir entities a DTOs
        public static DTO builderEntityDTO<DTO, Entity>(Entity entity)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Entity, DTO>(); //es para mapear desde entity a dto
            });
            IMapper iMapper = config.CreateMapper();
            var destination = iMapper.Map<Entity, DTO>(entity);
            return destination;
        }

        //Convertir dtos en entities.
        public static Entity builderDTOEntity<Entity, DTO>(DTO entity)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DTO, Entity>(); //es para mapear desde entity a dto
            });
            IMapper iMapper = config.CreateMapper();
            var destination = iMapper.Map<DTO, Entity>(entity);
            return destination;
        }

        public static IList<DTO> builderListEntityDTO<DTO, Entity>(IQueryable<Entity> listaInput)
        {
            var listOutput = new List<DTO>();
            foreach(Entity entity in listaInput)
            {
                listOutput.Add(builderEntityDTO<DTO, Entity>(entity));
            }
            return listOutput;
        }
    }
}
