using Microsoft.AspNetCore.Mvc;
using Pupita.Domain.Dto;
using Pupita.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pupita.API.Controllers
{
    [Route("api/[controller]")]
    public class ArtistController:Controller

    {
        private readonly IArtistRepository _repo;
        public ArtistController(IArtistRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> Get() //обращаемся ы репозиторий, чтобы оттуда пришли данные ВСЕ
        {
            try
            {
                return Ok(await _repo.GetAllArtist());//200 status of code it's Okeeey
            }
            catch (Exception ex) //отлавливаем ошибку, если она попадается в тру
            {
                return StatusCode(500, ex);
            }

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _repo.GetById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]

        public async Task<IActionResult> Post([FromBody] ArtistDto item)
        {
            try
            {
                return Ok(await _repo.CreatAsync(item));
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ArtistDto item)
        {
            try
            {
                return Ok(await _repo.UpdateAsync(item));
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                return Ok(await _repo.DeleteAsync(id));
            }
            catch (Exception ex) //отлавливаем ошибку, если она попадается в тру
            {
                return StatusCode(500, ex);
            }
        }


    }
}
