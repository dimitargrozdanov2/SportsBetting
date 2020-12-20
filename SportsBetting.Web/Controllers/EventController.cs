using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportsBetting.Services.Contracts;
using SportsBetting.Services.Dtos.EventDtos;
using SportsBetting.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsBetting.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService eventService;
        private readonly IMapper mapper;

        public EventController(IEventService eventService, IMapper mapper)
        {
            this.eventService = eventService;
            this.mapper = mapper;
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task <ActionResult<EventActionViewModel>> AddNewEventMode(CreateEventDto createInput)
        {
            var createdEvent = await this.eventService.CreateAsync(createInput);

            if (createdEvent == null)
            {
                return View("BadRequest");
            }
            //return View(mapper.Map<EventActionViewModel>(allEvents));
            return RedirectToAction("PreviewMode");
        }

        [HttpGet]
        public ActionResult AddNewEventMode()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditMode(int id)
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult<EventActionViewModel>> EditMode(int id, UpdateEventDto updateEventDto)
        {
            var updatedEvent = await this.eventService.UpdateAsync(id, updateEventDto);

            if (updatedEvent == null)
            {
                return View("BadRequest");
            }
            //return View(mapper.Map<EventActionViewModel>(allEvents));
            return RedirectToAction("PreviewMode");
        }
        public ActionResult<EventActionViewModel> PreviewMode()
        {
            var result = new List<EventActionViewModel>();
            var allEvents = this.eventService.GetAll().ToList();
            foreach (var eventDto in allEvents)
            {
                result.Add(mapper.Map<EventActionViewModel>(eventDto));
            }

            return View(result);
        }
    }
}
