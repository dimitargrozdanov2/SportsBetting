using SportsBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsBetting.Data.Repositories
{
    public class EventRepository : DbRepository<Event>
    {
        public EventRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
