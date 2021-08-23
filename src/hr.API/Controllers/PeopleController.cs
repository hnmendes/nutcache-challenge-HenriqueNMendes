using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using hr.Domain.Interfaces.Services;
using hr.API.ViewModels;
using System.Threading.Tasks;
using hr.Domain.Models.Entities;
using Microsoft.AspNetCore.Http;
using System.Net.Mime;

namespace hr.API.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _peopleService;
        private readonly IMapper _mapper;

        public PeopleController(IPeopleService peopleService, IMapper mapper)
        {
            _peopleService = peopleService;
            _mapper = mapper;
        }

        // GET: api/people
        [HttpGet]
        public async Task<IEnumerable<PeopleViewModel>> GetAsync()
        {            
            return _mapper.Map<IEnumerable<PeopleViewModel>>(await _peopleService.GetAll());

        }

        // GET api/people/5
        [HttpGet("{id:guid}")]
        public async Task<PeopleViewModel> GetAsync(Guid id)
        {
            return _mapper.Map<PeopleViewModel>(await _peopleService.GetById(id));
        }

        // POST api/people
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync([FromBody] PeopleViewModel people)
        {
            if(people == null)
            {
                return BadRequest();
            }

            var addedPeople = await _peopleService.Add(_mapper.Map<People>(people));

            return new ObjectResult(addedPeople) { StatusCode = StatusCodes.Status201Created };
        }

        // PUT api/people/5
        [HttpPut("{id:guid}")]
        public async Task PutAsync(Guid id, [FromBody] PeopleViewModel people)
        {
            await _peopleService.Set(_mapper.Map<People>(people));
        }

        // DELETE api/people/5
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var entity = await _peopleService.GetById(id);

                await _peopleService.Remove(entity);

                return new ObjectResult(null) { StatusCode = StatusCodes.Status204NoContent };

            }
            catch(Exception ex)
            {
                return BadRequest();
            }            
        }
    }
}
