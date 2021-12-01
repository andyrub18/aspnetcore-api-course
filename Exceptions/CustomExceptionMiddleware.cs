using Microsoft.AspNetCore.Http;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace my_books.Exceptions
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpcontext)
        {
            try
            {
                await _next(httpcontext);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(httpcontext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpcontext, Exception ex)
        {
            httpcontext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpcontext.Response.ContentType = "application/json";

            var response = new ErrorVM()
            {
                StatusCode = httpcontext.Response.StatusCode,
                Message = "Internal Server Error from the custom middleware",
                Path = "Path-goes-here"
            };

            return httpcontext.Response.WriteAsync(response.ToString());
        }
    }
}
