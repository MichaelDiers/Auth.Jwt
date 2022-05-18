namespace Auth.Jwt.Web.Controllers
{
    using System.Linq;
    using Auth.Jwt.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class AuthenticateController : Controller
    {
        public const string Name = "Authenticate";

        public IActionResult Index()
        {
            if (!this.TempData.TryGetValue(nameof(SignInViewModel), out var viewModel))
            {
                viewModel = new SignInViewModel();
            }

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Index([FromForm] SignInViewModel request)
        {
            if (this.ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(DashboardController.Index), DashboardController.Name);
            }

            var errors = this.ModelState.Values.Select(x => x.Errors).ToArray();

            return this.View(request);
        }
    }
}
