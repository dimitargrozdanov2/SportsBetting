using SportsBetting.Data.Models;
using SportsBetting.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsBetting.Data.Repositories
{
    public class EventRepository : DbRepository<Event>, IEventRepository
    {
        public EventRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
