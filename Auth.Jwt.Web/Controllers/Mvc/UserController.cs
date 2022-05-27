namespace Auth.Jwt.Web.Controllers.Mvc
{
    using System.Security.Claims;
    using Auth.Jwt.Web.Extensions;
    using Auth.Jwt.Web.ViewModels.User;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    ///     Display and edit the data of an authorized user.
    /// </summary>
    [Authorize]
    public class UserController : BaseController
    {
        /// <summary>
        ///     The automated user interface tests id of the view.
        /// </summary>
        public const string UserIndexViewAuit = nameof(UserController.UserIndexViewAuit);

        /// <summary>
        ///     Display the user data.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            this.SetAuit(UserController.UserIndexViewAuit);
            var user = this.HttpContext.User;
            var userViewModel = new UserViewModel(user.Claims.Get(ClaimTypes.Name));
            return this.View(userViewModel);
        }
    }
}
