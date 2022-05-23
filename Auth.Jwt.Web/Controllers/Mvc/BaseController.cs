namespace Auth.Jwt.Web.Controllers.Mvc
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    ///     Base for all controllers.
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        ///     Name of the auit attribute.
        /// </summary>
        public const string Auit = "auit";

        /// <summary>
        ///     Sets the auit data to the view data.
        /// </summary>
        /// <param name="auit"></param>
        protected void SetAuit(string auit)
        {
            this.ViewData[BaseController.Auit] = auit;
        }
    }
}
