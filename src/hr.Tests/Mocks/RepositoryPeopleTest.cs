using hr.Domain.Interfaces.Repositories;
using hr.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr.Tests.Mocks
{
    public class RepositoryPeopleTest : IRepositoryBase<People>
    {
        private readonly List<People> _peoples;

        public RepositoryPeopleTest()
        {
            _peoples = GeneratePeopleFakeData();
        }

        public async Task<People> Add(People entity)
        {
            await Task.Run(() => _peoples.Add(entity));

            return entity;
        }

        public async Task<People> Get(People entity)
        {
            var people = await Task.Run(() => _peoples.First(p => p.Id == entity.Id));

            return people;
        }

        public async Task<IEnumerable<People>> GetAll()
        {
            var peoples = await Task.Run(() => _peoples.AsQueryable());

            return peoples;
        }

        public async Task<People> GetById(Guid id)
        {
            try
            {
                var people = await Task.Run(() => _peoples.First(p => p.Id == id));

                return people;

            }catch
            {
                return null;
            }
        }

        public async Task Remove(People entity)
        {
            await Task.Run(() => _peoples.Remove(entity));
            await SaveChanges();

        }

        public Task<int> SaveChanges()
        {
            return Task.FromResult(1);
        }

        public async Task Set(People entity)
        {
            var people = await Task.Run(() => _peoples.Single(p => p.Id == entity.Id));

            people = entity;            

        }

        public void Dispose()
        {
        }

        private List<People> GeneratePeopleFakeData()
        {
            var peoples = new List<People>();

            var people1 = new People()
            {
                Id = new Guid("a5817648-db24-42dc-fe08-08d9646358e3"),
                BirthDate = DateTime.Now,
                CPF = "11111111111",
                Email = "testmail@mail.com",
                Gender = Domain.Models.Enums.Gender.Male,
                Name = "test1",
                StartDate = DateTime.Now,
                Team = Domain.Models.Enums.Team.Frontend
            };

            var people2 = new People()
            {
                Id = Guid.NewGuid(),
                BirthDate = DateTime.Now,
                CPF = "11111111111",
                Email = "testmail@mail.com",
                Gender = Domain.Models.Enums.Gender.Male,
                Name = "test1",
                StartDate = DateTime.Now,
                Team = Domain.Models.Enums.Team.Frontend
            };

            var people3 = new People()
            {
                Id = Guid.NewGuid(),
                BirthDate = DateTime.Now,
                CPF = "11111111111",
                Email = "testmail@mail.com",
                Gender = Domain.Models.Enums.Gender.Male,
                Name = "test1",
                StartDate = DateTime.Now,
                Team = Domain.Models.Enums.Team.Frontend
            };

            var people4 = new People()
            {
                Id = Guid.NewGuid(),
                BirthDate = DateTime.Now,
                CPF = "11111111111",
                Email = "testmail@mail.com",
                Gender = Domain.Models.Enums.Gender.Male,
                Name = "test1",
                StartDate = DateTime.Now,
                Team = Domain.Models.Enums.Team.Frontend
            };

            var people5 = new People()
            {
                Id = Guid.NewGuid(),
                BirthDate = DateTime.Now,
                CPF = "11111111111",
                Email = "testmail@mail.com",
                Gender = Domain.Models.Enums.Gender.Male,
                Name = "test1",
                StartDate = DateTime.Now,
                Team = Domain.Models.Enums.Team.Frontend
            };

            peoples.Add(people1);
            peoples.Add(people2);
            peoples.Add(people3);
            peoples.Add(people4);
            peoples.Add(people5);

            return peoples;
        }
    }
}
