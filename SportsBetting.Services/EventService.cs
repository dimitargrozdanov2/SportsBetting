using AutoMapper;
using SportsBetting.Data.Exceptions;
using SportsBetting.Data.Models;
using SportsBetting.Data.Repositories.Contracts;
using SportsBetting.Data.Utils;
using SportsBetting.Services.Contracts;
using SportsBetting.Services.Dtos.EventDtos;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<EventDto> CreateAsync(CreateEventDto createInput)
        {
            if (createInput == null) throw new BadRequestException("No data provided");

            var entity = mapper.Map<Event>(createInput);
            await eventRepository.AddAsync(entity);
            var result = mapper.Map<EventDto>(entity);
            return result;
        }

        public async Task DeleteAsync(int id)
        {
            ObjectCheck.PrimaryKeyCheck(id, $"primaryKey <= 0 in {nameof(Event)}");
            var entityToBeDeleted = await GetAsync(id);
            if (entityToBeDeleted == null) throw new NotFoundException("Entity could not be found");
            await eventRepository.DeleteAsync(id);
        }

        public IEnumerable<EventDto> GetAll(Expression<Func<Event, bool>> filter = null)
        {
            return (eventRepository.GetAll(filter)).Select(i => mapper.Map<EventDto>(i));
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
