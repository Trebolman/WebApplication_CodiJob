using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodiJobServices.Model.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApplication_CodiJob.Model.CodiJobDb;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication_CodiJob.Controllers
{
    [Route("api/[controller]")]
    public class ProyectoController : Controller
    {
        public IProyectoRepository repository;
        //Creando un constructor
        public ProyectoController(IProyectoRepository repo)
        {
            this.repository = repo; //con esto, tenemos acceso a los repositorios
        }

        // GET: api/<controller>
        [HttpGet]
        public IQueryable<Tproyectos> Get()
        {
            return repository.Items;
        }

        // GET api/<controller>/5
        [HttpGet("{ProyectoId}")]
        public Tproyectos Get(Guid ProyectoId)
        {
            return repository.Items.Where(p => p.ProyectoId == ProyectoId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Tproyectos proyecto)
        {
            repository.Save(proyecto);
            return Ok(true); //ok es codigo 200
        }

        // PUT api/<controller>/5
        [HttpPut("{ProyectoId}")]
        public IActionResult Put(Guid ProyectoId, [FromBody]Tproyectos proyecto)
        {
            proyecto.ProyectoId = ProyectoId;
            repository.Save(proyecto);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{ProyectoId}")]
        public IActionResult Delete(Guid ProyectoId)
        {
            repository.Delete(ProyectoId);
            return Ok(200);
        }

        [HttpGet("{pageSize}/{page}")]
        public IQueryable<Tproyectos> Get(int pageSize, int page)
        {
            return repository.FilterProyectos(pageSize, page);
        }
    }
}
