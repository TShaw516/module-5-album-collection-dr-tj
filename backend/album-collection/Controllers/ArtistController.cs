﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using album_collection.Models;
using album_collection.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace album_collection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        List<string> all = new List<string>()
        {
            "String 1",
            "String 2",
            "String 3"
        };

        IRepository<Artist> artistRepo;

        public ArtistController(IRepository<Artist> artistRepo)
        {
            this.artistRepo = artistRepo;
        }

        // GET: api/Artist
        [HttpGet]
        public IEnumerable<Artist> Get()
        {
            return artistRepo.GetAll();
        }

        // GET: api/Artist/5
        [HttpGet("{id}")]
        public Artist Get(int id)
        {
            return artistRepo.GetById(id);
        }

        // POST: api/Artist
        [HttpPost]
        public IEnumerable<Artist> Post([FromBody] Artist value)
        {
            artistRepo.Create(value);
            return artistRepo.GetAll();
        }

        // PUT: api/Artist/5
        [HttpPut("{id}")]
        public IEnumerable<Artist> Put([FromBody] Artist value)
        {
            artistRepo.Update(value);
            return artistRepo.GetAll();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IEnumerable<Artist> Delete(int id)
        {
            var artist = artistRepo.GetById(id);
            artistRepo.Delete(artist);
            return artistRepo.GetAll();
        }
    }
}