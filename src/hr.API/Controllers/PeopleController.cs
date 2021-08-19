using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using hr.Domain.Interfaces.Services;

namespace hr.API.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        // GET: api/people
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/people/5
        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            return "value";
        }

        // POST api/people
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/people/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/people/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
