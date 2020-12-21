using Microsoft.AspNetCore.Mvc;

namespace SportsBetting.Web.Controllers
{
    public class ErrorController : Controller
    {

        public IActionResult PageNotFound()
        {
            return this.View();
        }

        public IActionResult AlreadyExists(string error)
        {
            this.ViewData["Error"] = error;
            return this.View();
        }

        public IActionResult BadRequestPage(string error)
        {
            this.ViewData["Error"] = error;
            return this.View();
        }

    }
}
