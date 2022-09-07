using Core.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Core.Utilities.Middleware
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(httpContext, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";

            if (e.GetType() == typeof(ValidationFailure))
                return validationException(httpContext, e);

            if (e.GetType() == typeof(UnAuthorizeException))
                return unAuthorizeException(httpContext, e);

            return internalServerException(httpContext, e);
        }

        private Task internalServerException(HttpContext httpContext, Exception e)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string message = "Internal Server Error";

            return httpContext.Response.WriteAsync(new ErrorDetails
            {
                Message = message,
                StatusCode = httpContext.Response.StatusCode
            }.ToString());
        }

        private Task unAuthorizeException(HttpContext httpContext, Exception e)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

            return httpContext.Response.WriteAsync(new ErrorDetails
            {
                Message = e.Message,
                StatusCode = httpContext.Response.StatusCode
            }.ToString());
        }

        private Task validationException(HttpContext httpContext, Exception e)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            IEnumerable<ValidationFailure> errors = ((ValidationException)e).Errors;
            return httpContext.Response.WriteAsync(new ValidationErrorDetails
            {
                Message = e.Message,
                StatusCode = httpContext.Response.StatusCode,
                Errors = errors
            }.ToString());
        }
    }
}
