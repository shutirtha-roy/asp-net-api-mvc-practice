using AutoMapper;
using FirstDemo.API.Models;
using FirstDemo.Infrastructure.BusinessObjects;

namespace FirstDemo.API.Profiles
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<CourseModel, Course>()
                .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Title))
                .ReverseMap();
        }
    }
}
