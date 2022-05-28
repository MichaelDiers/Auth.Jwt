namespace Auth.Jwt.Web.Filters
{
    using Auth.Jwt.Web.Controllers.Mvc;
    using Auth.Jwt.Web.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    /// <summary>
    ///     Conditional redirect if the email of the user is not validated.
    /// </summary>
    public class EmailValidatedFilter : IActionFilter
    {
        /// <summary>
        ///     The name of the claim type.
        /// </summary>
        public const string IsEmailValidatedClaimType = "IsEmailValidated";

        /// <summary>
        ///     Called after the action executes, before the action result.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext" />.</param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        /// <summary>
        ///     Called before the action executes, after model binding is complete.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext" />.</param>
        public async void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated &&
                !context.HttpContext.User.HasClaim(
                    EmailValidatedFilter.IsEmailValidatedClaimType,
                    true.ToString()) &&
                context.Controller.GetType() != typeof(AuthenticateController))
            {
                context.Result = new RedirectToActionResult(
                    nameof(AuthenticateController.ValidateEmail),
                    nameof(AuthenticateController).ControllerName(),
                    null);
                await context.Result.ExecuteResultAsync(context);
            }
        }
    }
}
