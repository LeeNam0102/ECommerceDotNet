using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECommerceDotNet.Common.Filters
{
    public class AuthenFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Items["user_id"] == null)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}


//Use: [ServiceFilter(typeof(AuthenFilter))]