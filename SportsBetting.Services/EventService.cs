﻿using AutoMapper;
using SportsBetting.Data.Exceptions;
using SportsBetting.Data.Models;
using SportsBetting.Data.Repositories.Contracts;
using SportsBetting.Data.Utils;
using SportsBetting.Services.Contracts;
using SportsBetting.Services.Dtos.EventDtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SportsBetting.Services
{
    public class EventService : IEventService
    {
        private readonly IMapper mapper;
        private readonly IEventRepository eventRepository;
        public EventService(IEventRepository eventRepository, IMapper mapper)
        {
            this.eventRepository = eventRepository;
            this.mapper = mapper;
        }

        public async Task CreateAsync()
        {
            var todayDate = DateTime.UtcNow.Date;
            var entity = new Event() { StartDate = todayDate.AddHours(23).AddMinutes(59).AddSeconds(59) };
            await eventRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            ObjectCheck.PrimaryKeyCheck(id, $"primaryKey <= 0 in {nameof(Event)}");
            var entityToBeDeleted = await GetAsync(id);
            if (entityToBeDeleted == null) throw new NotFoundException("Entity could not be found");
            await eventRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<EventDto>> GetAll(Expression<Func<Event, bool>> filter = null)
        {
            var events = await eventRepository.GetAll(filter);
            foreach (var e in events)
            {
                e.OddsForDraw = Math.Round(e.OddsForDraw, 2);
                e.OddsForFirstTeam = Math.Round(e.OddsForFirstTeam, 2);
                e.OddsForSecondTeam = Math.Round(e.OddsForSecondTeam, 2);
            }
            return this.mapper.Map<IEnumerable<EventDto>>(events);
        }

        public async Task<EventDto> GetSingleAsync(Expression<Func<Event, bool>> filter)
        {
            var singleEntity = await eventRepository.GetSingleAsync(filter);
            return singleEntity == null ? throw new NotFoundException("No data found") : mapper.Map<EventDto>(singleEntity);
        }

        public async Task<EventDto> GetAsync(int id)
        {
            ObjectCheck.PrimaryKeyCheck(id, $"primaryKey <= 0 in {nameof(Event)}");
            var entity = await eventRepository.GetAsync(id);
            return entity == null ? throw new NotFoundException("No data found") : mapper.Map<EventDto>(entity);
        }

        public async Task UpdateAsync(int id, UpdateEventDto editInput)
        {
            ObjectCheck.PrimaryKeyCheck(id, $"id <= 0 in {nameof(UpdateEventDto)}");
            var entityToBeUpdated = await eventRepository.GetAsync(id);
            if (entityToBeUpdated == null) throw new BadRequestException("No data provided");
            var entity = mapper.Map(editInput, entityToBeUpdated);
            entity.Id = id;
            await eventRepository.UpdateAsync(entityToBeUpdated);
        }
    }
}
