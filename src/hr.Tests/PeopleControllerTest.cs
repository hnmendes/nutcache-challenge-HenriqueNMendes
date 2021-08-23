using AutoMapper;
using hr.API.Controllers;
using hr.API.ViewModels;
using hr.Domain.Interfaces.Services;
using hr.Tests.Mocks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using hr.Domain.Models.Entities;
using System;

namespace hr.Tests
{
    [TestClass]
    public class PeopleControllerTest
    {
        private readonly IPeopleService _peopleService;
        private readonly IMapper _mapper;

        public PeopleControllerTest()
        {
            _peopleService = new ServicePeopleTest();

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MapperProfile());
                });

                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [TestMethod]
        public async Task GetPeopleById_ShouldReturnAPeopleAsync()
        {
            var controller = new PeopleController(_peopleService, _mapper);

            var response = await controller.GetAsync(new System.Guid("a5817648-db24-42dc-fe08-08d9646358e3"));
            var okResult = response as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.IsTrue(okResult is OkObjectResult);
            Assert.IsInstanceOfType(okResult.Value, typeof(PeopleViewModel));
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

        }

        [TestMethod]
        public async Task GetPeopleById_ShouldNotReturnAPeopleAsync()
        {
            var controller = new PeopleController(_peopleService, _mapper);

            var response = await controller.GetAsync(System.Guid.NewGuid());
            var notFoundResult = response as NotFoundResult;

            Assert.IsNotNull(notFoundResult);
            Assert.IsTrue(notFoundResult is NotFoundResult);
            Assert.AreEqual(StatusCodes.Status404NotFound, notFoundResult.StatusCode);
        }


        [TestMethod]
        public async Task GetAllPeoplesAsync_ShouldReturnAllPeoples()
        {
            var controller = new PeopleController(_peopleService, _mapper);

            var response = await controller.GetAsync();
            var okResult = response as OkObjectResult;

            var data = okResult.Value as IEnumerable<PeopleViewModel>;

            Assert.AreEqual(data.Count(), 5);
            Assert.IsNotNull(okResult);
            Assert.IsTrue(okResult is OkObjectResult);
            Assert.IsInstanceOfType(okResult.Value, typeof(List<PeopleViewModel>));
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [TestMethod]
        public async Task AddPeopleAsync_ShouldReturnCreated()
        {
            var peopleVM = new PeopleViewModel()
            {
                Id = Guid.NewGuid(),
                BirthDate = DateTime.Now,
                CPF = "11111111111",
                Email = "testmailVM@mail.com",
                Gender = Domain.Models.Enums.Gender.Male,
                Name = "test1",
                StartDate = DateTime.Now,
                Team = Domain.Models.Enums.Team.Frontend
            };

            var controller = new PeopleController(_peopleService, _mapper);

            var response = await controller.PostAsync(peopleVM);
            var createdResult = response as ObjectResult;

            var data = createdResult.Value as PeopleViewModel;

            Assert.IsInstanceOfType(data, typeof(PeopleViewModel));
            Assert.IsNotNull(createdResult);
            Assert.AreEqual(StatusCodes.Status201Created, createdResult.StatusCode);
            Assert.IsTrue(createdResult is ObjectResult);

        }

        [TestMethod]
        public async Task EditPeopleAsync_ShouldReturnNoContent204()
        {
            var controller = new PeopleController(_peopleService, _mapper);

            var peopleVM = new PeopleViewModel()
            {
                Id = new Guid("a5817648-db24-42dc-fe08-08d9646358e3"),
                BirthDate = DateTime.Now,
                CPF = "11111111111",
                Email = "lbf@mail.com",
                Gender = Domain.Models.Enums.Gender.Male,
                Name = "test1",
                StartDate = DateTime.Now,
                Team = Domain.Models.Enums.Team.Frontend
            };

            var response = await controller.PutAsync(new Guid("a5817648-db24-42dc-fe08-08d9646358e3"), peopleVM);
            var noContentResult = response as ObjectResult;

            Assert.IsNotNull(noContentResult);
            Assert.AreEqual(StatusCodes.Status204NoContent, noContentResult.StatusCode);
            Assert.IsTrue(noContentResult is ObjectResult);

        }

        [TestMethod]
        public async Task DeletePeopleAsync_ShouldReturnNoContent204()
        {
            var controller = new PeopleController(_peopleService, _mapper);

            var response = await controller.DeleteAsync(new Guid("a5817648-db24-42dc-fe08-08d9646358e3"));

            var noContentResult = response as ObjectResult;

            Assert.IsNotNull(noContentResult);
            Assert.AreEqual(StatusCodes.Status204NoContent, noContentResult.StatusCode);
            Assert.IsTrue(noContentResult is ObjectResult);
        }
    }
}
