using AutoMapper;
using hr.API.ViewModels;
using hr.Domain.Models.Entities;

namespace hr.API.Config
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<People, PeopleViewModel>().ReverseMap();
        }
    }
}
