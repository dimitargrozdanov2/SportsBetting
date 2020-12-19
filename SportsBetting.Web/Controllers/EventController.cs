using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportsBetting.Services.Contracts;
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


        [HttpGet]
        public ActionResult<EventActionViewModel> PreviewMode()
        {
            var result = new List<EventActionViewModel>();
            //await service. and add those props to the view model and return it.
            var allEvents = this.eventService.GetAll().ToList();
            foreach (var eventDto in allEvents)
            {
                result.Add(mapper.Map<EventActionViewModel>(eventDto));
            }

            //if (model == null)
            //{
            //    return View("NotFound");
            //}
            return View(result);
        }
    }
}
