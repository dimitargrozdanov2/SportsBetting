using AutoMapper;
using SportsBetting.Services.Dtos.EventDtos;
using SportsBetting.Web.Models;

namespace SportsBetting.Web.Infrastructure
{
    public class ControllerMappingProfile : Profile
    {
        public ControllerMappingProfile()
        {
            this
                .CreateMap<EventActionViewModel, EventDto>().ReverseMap();
        }
    }
}
