using AutoMapper;
using hr.API.ViewModels;
using hr.Domain.Models.Entities;

namespace hr.Tests.Mocks
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<People, PeopleViewModel>().ReverseMap();
        }
    }
}
