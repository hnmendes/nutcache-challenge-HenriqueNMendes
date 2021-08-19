using hr.Domain.Interfaces.Repositories;
using hr.Domain.Models.Entities;
using hr.Infra.Context;

namespace hr.Infra.Repository
{
    public class PeopleRepository : RepositoryBase<People>, IPeopleRepository
    {
        public PeopleRepository(HrDbContext context) : base(context)
        {

        }
    }
}
