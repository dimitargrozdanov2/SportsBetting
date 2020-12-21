using SportsBetting.Data.Models;
using SportsBetting.Data.Repositories.Contracts;

namespace SportsBetting.Data.Repositories
{
    public class EventRepository : DbRepository<Event>, IEventRepository
    {
        public EventRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
