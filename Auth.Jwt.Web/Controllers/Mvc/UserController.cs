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
        public const string IndexViewAuit = "auitD7896D4F-6606-43F6-BACE-D68FEE50B26F";

        /// <summary>
        ///     Display the user data.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            this.SetAuit(UserController.IndexViewAuit);
            var user = this.HttpContext.User;
            var userViewModel = new UserViewModel(user.Claims.Get(ClaimTypes.Name));
            return this.View(userViewModel);
        }
    }
}
