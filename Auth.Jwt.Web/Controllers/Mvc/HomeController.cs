namespace Auth.Jwt.Web.Controllers.Mvc
{
    using System.Diagnostics;
    using Auth.Jwt.Web.Extensions;
    using Auth.Jwt.Web.Models;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier});
        }

        public IActionResult Index()
        {
            return this.RedirectToAction(nameof(SignInController.SignIn), nameof(SignInController).ControllerName());
        }

        public IActionResult Privacy()
        {
            return this.View();
        }
    }
}
