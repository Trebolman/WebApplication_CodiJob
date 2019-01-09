using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.IRepositories;
using Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication_CodiJob.Controllers
{
    [Route("api/[controller]")]
    public class GrupoController : Controller
    {
        public IGrupoRepository repository;
        //Creando un constructor
        public GrupoController(IGrupoRepository repo)
        {
            this.repository = repo; //con esto, tenemos acceso a los repositorios
        }

        // GET: api/<controller>
        [HttpGet]
        public IQueryable<TGrupo> Get()
        {
            return repository.Items;
        }

        // GET api/<controller>/5
        [HttpGet("{GrupoId}")]
        public TGrupo Get(Guid GrupoId)
        {
            return repository.Items.Where(g => g.Id == GrupoId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]TGrupo grupo)
        {
            repository.Save(grupo);
            return Ok(true); //ok es codigo 200
        }

        // PUT api/<controller>/5
        [HttpPut("{GrupoId}")]
        public IActionResult Put(Guid GrupoId, [FromBody]TGrupo grupo)
        {
            grupo.Id = GrupoId;
            repository.Save(grupo);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{GrupoId}")]
        public IActionResult Delete(Guid GrupoId)
        {
            repository.Delete(GrupoId);
            return Ok(200);
        }

        [HttpGet("{pageSize}/{page}")]
        public IQueryable<TGrupo> Get(int pageSize, int page)
        {
            return repository.FilterGrupos(pageSize, page);
        }
    }
}
