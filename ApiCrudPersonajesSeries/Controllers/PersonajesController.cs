using ApiCrudPersonajesSeries.Models;
using ApiCrudPersonajesSeries.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace ApiCrudPersonajesSeries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositoryPersonajes repo;
        public PersonajesController(RepositoryPersonajes repo)
        {
           this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Personaje>>> GetPersonajes()
        {
            return await this.repo.GetPersonajesAsync();
        }

        [HttpGet]
        [Route("[action]/{serie}")]
        public async Task<ActionResult<List<Personaje>>> GetPersonajesBySerie(string serie)
        {
            var personajes = await this.repo.GetPersonajesBySerieAsync(serie);
            return Ok(personajes);
        }

        [HttpGet]

        [HttpGet("{id}")]
        public async Task<ActionResult<Personaje>> FindPersonaje(int id)
        {
            return await this.repo.FindPersonajeAsync(id);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> InsertPersonaje(Personaje personaje)
        {
            await this.repo.InsertPersonajeAsync(personaje.Id, personaje.Nombre, personaje.Imagen, personaje.Serie);
            return Ok();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult> UpdatePersonaje(Personaje personaje)
        {
            await this.repo.UpdatePersonajesAsync(personaje.Id, personaje.Nombre, personaje.Imagen, personaje.Serie);
            return Ok();
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<ActionResult<Personaje>> DeletePersonaje(int id)
        {
            await this.repo.DeletePersonajesAsync(id);
            return Ok();
        }
    }
}
