using hr.Domain.Interfaces.Repositories;
using hr.Domain.Interfaces.Services;
using hr.Domain.Models.Entities;

namespace hr.Domain.Services
{
    public class PeopleService : ServiceBase<People>, IPeopleService
    {

        private readonly IPeopleRepository _repository;

        public PeopleService(IPeopleRepository repository) : base(repository)
        {
            _repository = repository;
        }

    }
}
