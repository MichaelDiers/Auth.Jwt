namespace Auth.Jwt.Web.Controllers
{
    using System.Diagnostics;
    using Auth.Jwt.Web.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Localization;

    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> localizer;

        public HomeController(IStringLocalizer<HomeController> localizer)
        {
            this.localizer = localizer;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier});
        }

        public IActionResult Index()
        {
            this.ViewData["Title"] = this.localizer["Title"];
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }
    }
}
