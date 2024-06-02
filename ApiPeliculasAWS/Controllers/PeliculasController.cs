﻿using ApiPeliculasAWS.Models;
using ApiPeliculasAWS.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPeliculasAWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private RepositoryPeliculas repo;

        public PeliculasController(RepositoryPeliculas repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pelicula>>>
            Get()
        {
            return await this.repo.GetPeliculasAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pelicula>>
            GetId(int id)
        {
            return await this.repo.FindPeliculaAsync(id);
        }

        [HttpGet]
        [Route("[action]/{actor}")]
        public async Task<ActionResult<List<Pelicula>>>
            Find(string actor)
        {
            return await this.repo.GetPeliculasActoresAsync(actor);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Pelicula pelicula)
        {
            await this.repo.CreatePeliculaAsync(pelicula.Genero
                , pelicula.Titulo, pelicula.Argumento
                , pelicula.Foto, pelicula.Actores, pelicula.Precio
                , pelicula.YouTube);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Pelicula pelicula)
        {
            await this.repo.UpdatePeliculaAsync(pelicula.IdPelicula,
                pelicula.Genero
                , pelicula.Titulo, pelicula.Argumento
                , pelicula.Foto, pelicula.Actores, pelicula.Precio
                , pelicula.YouTube);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await this.repo.DeletePeliculaAsync(id);
            return Ok();
        }
    }
}
