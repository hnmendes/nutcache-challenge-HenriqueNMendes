using AutoMapper;
using hr.API.ViewModels;
using hr.Domain.Interfaces.Services;
using hr.Domain.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

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
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var entities = _mapper.Map<IEnumerable<PeopleViewModel>>(await _peopleService.GetAll());

                if (entities == null)
                {
                    return NotFound();
                }

                return Ok(entities);

            }
            catch (Exception ex)
            {
                return ApiError500(ex);
            }

        }

        // GET api/people/5
        [HttpGet("{id:guid}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync(Guid id)
        {

            try
            {
                var entity = _mapper.Map<PeopleViewModel>(await _peopleService.GetById(id));

                if (entity == null)
                {
                    return NotFound();
                }

                return Ok(entity);

            }
            catch (Exception ex)
            {
                return ApiError500(ex);
            }
        }

        // POST api/people
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostAsync([FromBody] PeopleViewModel people)
        {
            try
            {

                if (people == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                var addedPeople = await _peopleService.Add(_mapper.Map<People>(people));
                var addedPeopleVM = _mapper.Map<PeopleViewModel>(addedPeople);

                return ApiCreated201(addedPeopleVM);

            }
            catch (Exception ex)
            {
                return ApiError500(ex);
            }
        }

        // PUT api/people/5
        [HttpPut("{id:guid}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] PeopleViewModel people)
        {
            try
            {
                var entity = await _peopleService.GetById(id);

                if (entity == null)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _peopleService.Set(_mapper.Map<People>(people));

                return ApiOkNoContent204();

            }
            catch (Exception ex)
            {
                return ApiError500(ex);
            }
        }

        // DELETE api/people/5
        [HttpDelete("{id:guid}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var entity = await _peopleService.GetById(id);

                if (entity == null)
                {
                    return NotFound();
                }

                await _peopleService.Remove(entity);

                return ApiOkNoContent204();

            }
            catch (Exception ex)
            {
                return ApiError500(ex);
            }

        }

        private ObjectResult ApiError500(Exception ex)
        {
            //log the exception ex
            return StatusCode(500, new { errorMessage = "Contact the support." });
        }

        private ObjectResult ApiCreated201(PeopleViewModel people)
        {
            return StatusCode(201, people);
        }

        private ObjectResult ApiOkNoContent204()
        {
            return new ObjectResult(null) { StatusCode = StatusCodes.Status204NoContent };
        }
    }

}
