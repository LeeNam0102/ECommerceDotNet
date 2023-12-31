﻿using ECommerceDotNet.Common.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;


namespace ECommerceDotNet.Common.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILogger<JwtMiddleware> logger, IValidateTokenService validateTokenService)
        {
            //logic here
            var accessToken = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = validateTokenService.ValidateToken(accessToken);

            context.Items["user_id"] = userId;
            await _next(context);
        }
    }
}
