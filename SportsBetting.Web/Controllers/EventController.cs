using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsBetting.Services.Contracts;
using SportsBetting.Services.Dtos.EventDtos;
using SportsBetting.Web.Models;
using System.Collections.Generic;
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

        public async Task<IActionResult> PreviewMode()
        {
            var allEvents = await this.eventService.GetAll();
            var mappedEvents = mapper.Map<IList<EventActionViewModel>>(allEvents);
            return View(mappedEvents);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> AddNewEventMode(IFormCollection form)
        {
            await this.eventService.CreateAsync();
            return RedirectToAction("EditView");
        }

        [HttpGet]
        public ActionResult AddNewEventMode()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditView()
        {
            var allEvents = await this.eventService.GetAll();
            var mappedEvents = mapper.Map<IList<EventActionViewModel>>(allEvents);
            return View(mappedEvents);
        }

        [HttpGet]
        public async Task<IActionResult> EditMode(int id)
        {
            var dto = await eventService.GetSingleAsync(e => e.Id == id);
            var viewModel = mapper.Map<EventActionViewModel>(dto);
            return View(viewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> EditMode(int id, UpdateEventDto updateEventDto)
        {
            await this.eventService.UpdateAsync(id, updateEventDto);
            return RedirectToAction("PreviewMode");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteMode(int id)
        {
            var dto = await eventService.GetSingleAsync(e => e.Id == id);
            var viewModel = mapper.Map<EventActionViewModel>(dto);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMode(int id, IFormCollection form)
        {
            await this.eventService.DeleteAsync(id);
            return RedirectToAction("PreviewMode");
        }
    }
}
