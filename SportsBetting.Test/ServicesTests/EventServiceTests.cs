using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using SportsBetting.Data;
using SportsBetting.Data.Exceptions;
using SportsBetting.Data.Models;
using SportsBetting.Data.Repositories.Contracts;
using SportsBetting.Services;
using SportsBetting.Services.Dtos.EventDtos;
using SportsBetting.Web.Infrastructure;
using System;
using System.Threading.Tasks;

namespace SportsBetting.Test.ServicesTests
{
    [TestFixture]
    public class EventServiceTests
    {
        private Mock<IEventRepository> repoMock;
        private ServiceProvider serviceProvider;
        private int id = 0;


        private UpdateEventDto UpdateInput = new UpdateEventDto() { };


        [SetUp]
        protected void TestSetup()
        {
            var databaseName = Guid.NewGuid().ToString();

            repoMock = new Mock<IEventRepository>();

            var builder = new ServiceCollection()
                 .AddEntityFrameworkInMemoryDatabase()
                 .AddAutomapper()
                .AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase(databaseName).UseInternalServiceProvider(serviceProvider))
                .AddSingleton<EventService>()
                .AddSingleton(repoMock.Object);

            serviceProvider = builder.BuildServiceProvider();
        }

        protected void TestCleanup()
        {
            serviceProvider?.Dispose();
            serviceProvider = null;
        }


        [Test]
        public virtual void DeleteAsync_Should_Throw_NotFound_On_PrimaryKey_Null()
        {
            Assert.ThrowsAsync<NotFoundException>(() =>
                serviceProvider.GetService<EventService>().DeleteAsync(id));
        }

        [Test]
        public virtual void DeleteAsync_Should_Throw_NotFound_On_Entity_Null()
        {

            repoMock.Setup(r => r.GetAsync(id)).ReturnsAsync((Event)null);
            Assert.ThrowsAsync<NotFoundException>(async () =>
                await serviceProvider.GetService<EventService>().DeleteAsync(id));
        }

        [Test]
        public virtual Task GetAsync_Should_Throw_NotFound_On_PrimaryKey_Null()
        {
            Assert.ThrowsAsync<NotFoundException>(() =>
                serviceProvider.GetService<EventService>().GetAsync(id));
            return Task.CompletedTask;
        }


        [Test]
        public virtual Task UpdateAsync_Should_Throw_NotFound_On_PrimaryKey_Null()
        {
            Assert.ThrowsAsync<NotFoundException>(() =>
                serviceProvider.GetService<EventService>().UpdateAsync(id, UpdateInput));
            return Task.CompletedTask;
        }
    }
}
