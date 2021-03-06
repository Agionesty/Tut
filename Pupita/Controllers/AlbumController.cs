﻿using Microsoft.AspNetCore.Mvc;
using Pupita.Domain.Dto;
using Pupita.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using Pupita.Domain.Entities;
using Pupita.Core.EF;

namespace Pupita.API.Controllers
{
    [Route("api/[controller]")]

    public class AlbumController: Controller
    {
        private readonly IAlbumRepository _repo;
        private readonly MusicContext _context;
        //т.к контроллер работает с репозиторием 
        public AlbumController(IAlbumRepository repo, MusicContext context)
        {
            _context = context;
            _repo = repo;
        }
        

        public async Task<IActionResult> Get() //обращаемся ы репозиторий, чтобы оттуда пришли данные ВСЕ
        {
            try
            {
                return Ok(await _repo.GetAllAlbum());//200 status of code it's Okeeey
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
        public async Task<IActionResult> Post([FromBody] AlbumDto item)
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
        public async Task<IActionResult> Put ([FromBody] AlbumDto item)
        {
            try
            {
                return Ok(await _repo.UpdateAsync(item));
            }
            catch (Exception ex) //отлавливаем ошибку, если она попадается в тру
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

        [HttpGet("{artistname}")]

        public async Task<IActionResult> GetBySearch(string artistname)
        {
            try
            {
                return Ok(await _repo.GetBySearch(artistname));

            }

            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
       




    }
}
