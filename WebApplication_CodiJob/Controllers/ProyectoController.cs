using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.IServices;
using Domain;
using Domain.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication_CodiJob.Controllers
{
    [Route("api/[controller]")]
    public class ProyectoController : Controller
    {
        public IProyectoService Service;
        //Creando un constructor
        public ProyectoController(IProyectoService service)
        {
            this.Service = service; //con esto, tenemos acceso a los repositorios
        }

        //GET: api/<controller>
        [HttpGet]
        [Authorize]
        public IList<ProyectoDTO> Get()
        {
            return Service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{ProyId}")]
        public ProyectoDTO Get(Guid ProyId)
        {
            return Service.GetAll().Where(p => p.ProyId == ProyId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        //public IActionResult Post([FromBody]TProyecto proyecto)
        public IActionResult Post([FromBody] ProyectoDTO proyecto)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("El modelo no es valido");
            }
            //repository.Save(proyecto);
            Service.Insert(proyecto);
            return Ok(true); //ok es codigo 200
        }

        // PUT api/<controller>/5
        [HttpPut("{ProyId}")]
        public IActionResult Put(Guid ProyectoId, [FromBody]ProyectoDTO proyecto)
        {
            proyecto.ProyId = ProyectoId;
            Service.Insert(proyecto);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{ProyId}")]
        public IActionResult Delete(Guid ProyectoId)
        {
            Service.Delete(ProyectoId);
            return Ok(200);
        }

        //[HttpGet("{pageSize}/{page}")]
        //public IQueryable<TProyecto> Get(int pageSize, int page)
        //{
        //    return Service.FilterProyectos(pageSize, page);
        //}
    }
}
