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
    [Authorize]
    public class SkillController : Controller
    {
        public ISkillService Service;
        //Creando un constructor
        public SkillController(ISkillService service)
        {
            this.Service = service; //con esto, tenemos acceso a los repositorios
        }

        // GET: api/<controller>
        [HttpGet]
        public IList<SkillDTO> Get()
        {
            return Service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{SkillId}")]
        public SkillDTO Get(Guid SkillId)
        {
            return Service.GetAll().Where(s => s.SkillId == SkillId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]SkillDTO skill)
        {
            Service.Insert(skill);
            return Ok(true); //ok es codigo 200
        }

        // PUT api/<controller>/5
        [HttpPut("{SkillId}")]
        public IActionResult Put(Guid SkillId, [FromBody]SkillDTO skill)
        {
            skill.SkillId = SkillId;
            Service.Insert(skill);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{SkillId}")]
        public IActionResult Delete(Guid SkillId)
        {
            Service.Delete(SkillId);
            return Ok(200);
        }

        //[HttpGet("{pageSize}/{page}")]
        //public IQueryable<Tproyectos> Get(int pageSize, int page)
        //{
        //    return repository.FilterProyectos(pageSize, page);
        //}
    }
}
