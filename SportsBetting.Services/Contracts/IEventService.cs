using SportsBetting.Data.Models;
using SportsBetting.Services.Dtos.EventDtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SportsBetting.Services.Contracts
{
    public interface IEventService
    {
        Task<EventDto> CreateAsync(CreateEventDto createInput);
        Task DeleteAsync(int id);
        IEnumerable<EventDto> GetAll(Expression<Func<Event, bool>> filter = null);
        Task<EventDto> GetAsync(int id);
        Task<EventDto> GetSingleAsync(Expression<Func<Event, bool>> filter);
        Task UpdateAsync(int id, UpdateEventDto editInput);
    }
}
