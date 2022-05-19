namespace Auth.Jwt.Web.Controllers.Mvc
{
    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : Controller
    {
        public const string Name = "Dashboard";

        public IActionResult Index()
        {
            return this.View();
        }
    }
}
