using IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters
{
    public class AuthenticationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"];
            if (String.IsNullOrEmpty(token))
            {
                context.Result = new ObjectResult("Authorization header is needed") { StatusCode = 401 };
            }
            else if (!Guid.TryParse(token, out Guid parsedToken))
            {
                context.Result = new ObjectResult("Invalid token format") { StatusCode = 400 };
            }
            else
            {
                var sessionService = GetUserLogic(context);
                bool correctUser = sessionService.IsTheCorrectUser(parsedToken);
                if (!correctUser)
                {
                    context.Result = new ObjectResult("The token does not correspond to a existing user") { StatusCode = 401 };
                }
            }
        }
        private IUserLogic GetUserLogic(AuthorizationFilterContext context)
        {
            var sessionManagerObject = context.HttpContext.RequestServices.GetService(typeof(IUserLogic));
            var sessionService = sessionManagerObject as IUserLogic;

            return sessionService;
        }
    }
}
