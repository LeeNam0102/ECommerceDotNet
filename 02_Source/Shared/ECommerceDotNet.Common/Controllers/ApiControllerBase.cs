using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ECommerceDotNet.Common.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        protected async Task<string?> GetUserID()
        {
            return await Task.Run<string?>(() =>
            {
                if (Request != null && Request.Headers["UserID"].Any())
                {
                    return Request.Headers["UserID"];
                }

                return null;
            });
        }   
    }
}