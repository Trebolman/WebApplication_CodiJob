using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication_CodiJob.Controllers
{
    [Route("api/[controller]")]
    public class SkillController : Controller
    {
        public ISkillRepository repository;
        //Creando un constructor
        public SkillController(ISkillRepository repo)
        {
            this.repository = repo; //con esto, tenemos acceso a los repositorios
        }

        // GET: api/<controller>
        [HttpGet]
        public IQueryable<TSkill> Get()
        {
            return repository.Items;
        }

        // GET api/<controller>/5
        [HttpGet("{SkillId}")]
        public TSkill Get(Guid SkillId)
        {
            return repository.Items.Where(s => s.SkillId == SkillId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]TSkill skill)
        {
            repository.Save(skill);
            return Ok(true); //ok es codigo 200
        }

        // PUT api/<controller>/5
        [HttpPut("{SkillId}")]
        public IActionResult Put(Guid SkillId, [FromBody]TSkill skill)
        {
            skill.SkillId = SkillId;
            repository.Save(skill);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{SkillId}")]
        public IActionResult Delete(Guid SkillId)
        {
            repository.Delete(SkillId);
            return Ok(200);
        }

        //[HttpGet("{pageSize}/{page}")]
        //public IQueryable<Tproyectos> Get(int pageSize, int page)
        //{
        //    return repository.FilterProyectos(pageSize, page);
        //}
    }
}
