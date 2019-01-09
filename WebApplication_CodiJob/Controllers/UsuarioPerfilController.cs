using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.IServices;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodiJobServices2.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsuarioPerfilController : Controller
    {
        IUsuarioPerfilService Service;
        public UsuarioPerfilController(IUsuarioPerfilService service)
        {
            this.Service = service;
        }

        // GET: api/<controller>
        [HttpGet]
        public IList<UsuarioPerfilDTO> Get()
        {
            return Service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{UsuarioPerfilId}")]
        public UsuarioPerfilDTO Get(Guid UsuarioPerfilId)
        {
            return Service.GetAll()
                .Where(p => p.UsuperId == UsuarioPerfilId)
                .FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]UsuarioPerfilDTO usuarioPerfil)
        {
            Service.Insert(usuarioPerfil);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{UsuarioPerfilId}")]
        public IActionResult Put(Guid UsuarioPerfilId,
                        [FromBody]UsuarioPerfilDTO usuarioPerfil)
        {
            usuarioPerfil.UsuperId = UsuarioPerfilId;
            Service.Update(usuarioPerfil);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{UsuarioPerfilId}")]
        public IActionResult Delete(Guid UsuarioPerfilId)
        {
            Service.Delete(UsuarioPerfilId);
            return Ok(true);
        }
    }
}