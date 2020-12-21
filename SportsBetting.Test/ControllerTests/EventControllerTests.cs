using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using SportsBetting.Services.Contracts;
using SportsBetting.Services.Dtos.EventDtos;
using SportsBetting.Web.Controllers;
using SportsBetting.Web.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsBetting.Test.ControllerTests
{
    [TestFixture]
    public class EventControllerTests
    {
        private Mock<IEventService> eventServiceMock;
        private EventController sut;
        private ServiceProvider sp;
        private readonly List<EventDto> eventsDtos = new List<EventDto> {new EventDto(), new EventDto()};
        private readonly EventDto eventDto = new EventDto() { Id = 1 };

    [SetUp]
        protected void TestSetup()
        {
            var sp = new ServiceCollection()
               .AddAutomapper()
               .BuildServiceProvider();

            var Mapper = sp.GetRequiredService<IMapper>();

            this.eventServiceMock = new Mock<IEventService>();
            this.sut = new EventController(eventServiceMock.Object, Mapper);
        }

        [TearDown]
        protected void TestCleanup()
        {
            sp?.Dispose();

            sp = null;
        }

        [Test]
        public async Task PreviewMode_Should_Return_View()
        {
            eventServiceMock.Setup(e => e.GetAll(null)).ReturnsAsync(eventsDtos);
            var result = await this.sut.PreviewMode();
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public async Task EditView_Should_Return_View()
        {
            eventServiceMock.Setup(e => e.GetAll(null)).ReturnsAsync(eventsDtos);
            var result = await this.sut.EditView();
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public async Task EditMode_Should_Return_View()
        {
            eventServiceMock.Setup(e => e.GetSingleAsync(r => r.Id == 1)).ReturnsAsync(eventDto);
            var result = await this.sut.EditMode(eventDto.Id);
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public async Task DeleteMode_Should_Return_View()
        {
            eventServiceMock.Setup(e => e.GetSingleAsync(r => r.Id == 1)).ReturnsAsync(eventDto);
            var result = await this.sut.DeleteMode(eventDto.Id);
            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}
