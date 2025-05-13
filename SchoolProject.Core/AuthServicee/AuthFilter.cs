using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SchoolProject.Services.Abstract.AuthServices;

namespace SchoolProject.Core.AuthServicee
{
    public class AuthFilter : IAsyncActionFilter
    {
        private readonly ICurrentUserServices _currentUserServices;

        public AuthFilter(ICurrentUserServices currentUserServices)
        {
            _currentUserServices = currentUserServices;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var roles = await _currentUserServices.GetUserRoleAsync();

                if (roles.All(x => x != "User"))
                {
                    context.Result = new ObjectResult("Forbidden")
                    {
                        StatusCode = StatusCodes.Status403Forbidden
                    };
                }


            }

            else
            {
                await next();
            }
        }
    }
}
