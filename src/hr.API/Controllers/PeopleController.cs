using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using hr.Domain.Interfaces.Services;
using hr.API.ViewModels;
using System.Threading.Tasks;
using hr.Domain.Models.Entities;

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
        public async Task PostAsync([FromBody] PeopleViewModel people)
        {
            await _peopleService.Add(_mapper.Map<People>(people));
        }

        // PUT api/people/5
        [HttpPut("{id:guid}")]
        public async Task PutAsync(Guid id, [FromBody] PeopleViewModel people)
        {
            await _peopleService.Set(_mapper.Map<People>(people));
        }

        // DELETE api/people/5
        [HttpDelete("{id:guid}")]
        public void Delete(Guid id)
        {
        }
    }
}
