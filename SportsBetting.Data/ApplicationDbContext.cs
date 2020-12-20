using Microsoft.EntityFrameworkCore;
using SportsBetting.Data.Models;

namespace SportsBetting.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Event>().Property(e => e.StartDate).HasDefaultValueSql("timezone('utc', now())");
            base.OnModelCreating(builder);
        }
    }
}
