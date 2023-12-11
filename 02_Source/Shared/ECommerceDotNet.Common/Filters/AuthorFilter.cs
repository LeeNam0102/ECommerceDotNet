using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECommerceDotNet.Common.Filters
{
    public class AuthorFilter : IAuthorizationFilter
    {
        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            var userId = context.HttpContext.Items["user_id"];

            if (userId == null)
            {
                context.Result = new UnauthorizedResult();
            }


            string controllerName = context.HttpContext.Request.RouteValues["controller"].ToString();
            string actionName = context.HttpContext.Request.RouteValues["action"].ToString();

            var permissions = new HashSet<string>();
            HttpClient client = new HttpClient();
            IConfiguration configuration = context.HttpContext.RequestServices.GetService(typeof(IConfiguration)) as IConfiguration;
            string apiUrl = configuration["Urls:AccountUrl"];

            using (HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, apiUrl + "/api/Account/user/GetAllPermissions?userId=" + userId))
            {
                using (HttpResponseMessage responseMessage = client.Send(requestMessage))
                {
                    responseMessage.EnsureSuccessStatusCode();

                    if (responseMessage.StatusCode != HttpStatusCode.NoContent)
                    {
                        permissions = await responseMessage.Content.ReadFromJsonAsync<HashSet<string>>();
                    }
                }
            }

            if (!permissions.Contains(controllerName + "." + actionName))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}

//Use: [ServiceFilter(typeof(AuthorFilter))]