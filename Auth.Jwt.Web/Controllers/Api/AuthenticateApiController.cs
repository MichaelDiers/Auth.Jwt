namespace Auth.Jwt.Web.Controllers.Api
{
    using System.Threading.Tasks;
    using Auth.Jwt.Web.Contracts.Models.Response;
    using Auth.Jwt.Web.Contracts.Services;
    using Auth.Jwt.Web.Models.Requests;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AuthenticateApiController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticateApiController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<ActionResult<ITokenResponse>> SignInAsync([FromBody] SignInRequest request)
        {
            var response = await this.authenticationService.AuthenticateAsync(request);
            return new JsonResult(response);
        }
    }
}
