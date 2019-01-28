using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.IRepositories;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.IServices;
using Application.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication_CodiJob.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class GrupoController : Controller
    {
        public IGrupoService Service;
        //Creando un constructor
        public GrupoController(IGrupoService service)
        {
            this.Service = service; //con esto, tenemos acceso a los repositorios
        }

        // GET: api/<controller>
        [HttpGet]
        public IList<GrupoDTO> Get()
        {
            return Service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{GrupoId}")]
        public GrupoDTO Get(Guid GrupoId)
        {
            return Service.GetAll().Where(g => g.GrupoId == GrupoId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]GrupoDTO grupo)
        {
            Service.Insert(grupo);
            return Ok(true); //ok es codigo 200
        }

        // PUT api/<controller>/5
        [HttpPut("{GrupoId}")]
        public IActionResult Put(Guid GrupoId, [FromBody]GrupoDTO grupo)
        {
            grupo.GrupoId = GrupoId;
            Service.Insert(grupo);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{GrupoId}")]
        public IActionResult Delete(Guid GrupoId)
        {
            Service.Delete(GrupoId);
            return Ok(200);
        }

        //[HttpGet("{pageSize}/{page}")]
        //public IQueryable<GrupoDTO> Get(int pageSize, int page)
        //{
        //    return repository.FilterGrupos(pageSize, page);
        //}
    }
}
