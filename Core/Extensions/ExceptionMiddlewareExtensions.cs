using Core.Utilities.Middleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
