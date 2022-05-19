namespace Auth.Jwt.Web.Controllers.Mvc
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "MyRoles")]
    public class DashboardController : Controller
    {
        public const string Name = "Dashboard";

        public IActionResult Index()
        {
            return this.View();
        }
    }
}
