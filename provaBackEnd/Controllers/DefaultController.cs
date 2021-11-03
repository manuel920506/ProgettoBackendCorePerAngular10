﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace provaBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        // GET: api/<DefaultController>
        [HttpGet]
        public string Get()
        {
            return "Applicazione running" ;
        }

        // GET api/<DefaultController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DefaultController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DefaultController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DefaultController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
