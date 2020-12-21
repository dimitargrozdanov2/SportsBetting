using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using SportsBetting.Data;
using SportsBetting.Data.Exceptions;
using SportsBetting.Data.Models;
using SportsBetting.Data.Repositories;
using SportsBetting.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsBetting.Test.RepositoryTests
{
    [TestFixture]
    public class EventRepositoryTests
    {
         protected ServiceProvider serviceProvider;

        [SetUp]
        public void Setup()
        {
            var databaseName = Guid.NewGuid().ToString();
            TestCleanup();

            var builder = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .AddAutomapper()
                .AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase(databaseName).UseInternalServiceProvider(serviceProvider))
                .AddSingleton<EventRepository>();

            serviceProvider = builder.BuildServiceProvider();
        }

        [TearDown]
        protected void TestCleanup()
        {
            serviceProvider?.Dispose();
            serviceProvider = null;
        }

        protected Event CreateEntity = new Event() { Id = 1, Name = "Everton-Manchester" };
        protected virtual List<string> CreateIgnoreProperties { get; set; } = new List<string>();
        protected List<Event> CreatedEntities = new List<Event>() { new Event(), new Event() };
        protected Event UpdatedEntity = new Event() { Id = 1, Name = "Manchester-Everton" };


        [Test]
        public async Task Add_Should_Throw_Not_Found()
        {
            Assert.ThrowsAsync<NotFoundException>(async () =>
            await serviceProvider.GetService<EventRepository>().AddAsync(null));
        }

        [Test]
        public async Task Add_Should_Add_to_Database()
        {
            var result = await serviceProvider.GetService<EventRepository>().AddAsync(CreateEntity);
            result.AssertEqualProperties(CreateEntity);
        }

        [Test]
        public async Task Get_Should_Return_Entity()
        {
            using var dbContext = serviceProvider.GetService<ApplicationDbContext>();
            await dbContext.Set<Event>().AddAsync(CreateEntity);
            await dbContext.SaveChangesAsync();
            var result = await serviceProvider.GetService<EventRepository>().GetAsync(CreateEntity.Id);
            result.AssertEqualProperties(CreateEntity);
        }

        [Test]
        public async Task Get_Should_Return_Not_Found()
        {
            using var dbContext = serviceProvider.GetService<ApplicationDbContext>();
            await dbContext.Set<Event>().AddAsync(CreateEntity);
            await dbContext.SaveChangesAsync();
            Assert.ThrowsAsync<NotFoundException>(async () =>
                await serviceProvider.GetService<EventRepository>().GetAsync(default(int)));
        }

        [Test]
        public async Task GetAll_Should_Return_Entities()
        {
            using var dbContext = serviceProvider.GetService<ApplicationDbContext>();
            dbContext.Set<Event>().AddRange(CreatedEntities);
            dbContext.SaveChanges();
            var result = await serviceProvider.GetService<EventRepository>().GetAll();
            var x = result.ToList();
            Assert.AreEqual(x.Count, 2);
        }

        [Test]
        public async Task GetSingle_Should_Return_SingleEntity()
        {
            using var dbContext = serviceProvider.GetService<ApplicationDbContext>();
            await dbContext.Set<Event>().AddAsync(CreateEntity);
            await dbContext.SaveChangesAsync();
            var result = await serviceProvider.GetService<EventRepository>().GetSingleAsync(e => e.Id.Equals(CreateEntity.Id));
            result.AssertEqualProperties(CreateEntity);
        }

        [Test]
        public async Task Update_Should_Return_ModifiedEntity()
        {
            using var dbContext = serviceProvider.GetService<ApplicationDbContext>();
            dbContext.Set<Event>().Add(CreateEntity);
            dbContext.SaveChanges();
            var updated = dbContext.Set<Event>().Find(CreateEntity.Id);
            UpdatedEntity.CopyProperties(updated);
            await serviceProvider.GetService<EventRepository>().UpdateAsync(updated);
            updated = dbContext.Set<Event>().Find(UpdatedEntity.Id);
            updated.AssertEqualProperties(UpdatedEntity);
        }

        [Test]
        public void Update_Should_Return_Not_Found()
        {
            Assert.ThrowsAsync<NotFoundException>(async () =>
                await serviceProvider.GetService<EventRepository>().UpdateAsync(null));
        }

        [Test]
        public async Task Delete_Should_Delete_Entity()
        {
            using var dbContext = serviceProvider.GetService<ApplicationDbContext>();
            await dbContext.Set<Event>().AddAsync(CreateEntity);
            await dbContext.SaveChangesAsync();
            await serviceProvider.GetService<EventRepository>().DeleteAsync(CreateEntity.Id);
            var deletedEntity = await dbContext.Set<Event>().FindAsync(CreateEntity.Id);
            Assert.IsNull(deletedEntity);
        }
    }
}
