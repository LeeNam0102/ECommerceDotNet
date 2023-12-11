using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ECommerceDotNet.Common.Middlewares
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;

        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILogger<ExceptionHandler> logger)
        {
            try
            {
                await _next(context);
            }
            catch (ArgumentException ex)
            {
                logger.LogError(ex.ToString());
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (NotImplementedException ex)
            {
                logger.LogError(ex.ToString());
                context.Response.StatusCode = (int)HttpStatusCode.NotImplemented;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(ex.Message);
            }
        }
    }
}
