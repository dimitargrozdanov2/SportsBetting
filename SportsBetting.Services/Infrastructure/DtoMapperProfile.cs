﻿using AutoMapper;
using SportsBetting.Data.Models;
using SportsBetting.Services.Dtos.EventDtos;

namespace SportsBetting.Services.Infrastructure
{
    public class DtoMapperProfile : Profile
    {
        public DtoMapperProfile()
        {
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Event, CreateEventDto>().ReverseMap();
            CreateMap<Event, UpdateEventDto>().ReverseMap();

            //creates maps between models and dtos that will be used in the services.
        }

    }
}
