﻿using System;

public class GlobalExceptionHandler
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            try
            {
                await _next(httpContext);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                await ConvertException(httpContext, ex);
            }
        }


        private Task ConvertException(HttpContext context, Exception exception)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";

            var result = string.Empty;

            switch (exception)
            {
                case KeyNotFoundException _:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = GetErrorMessage("The specified resource could not be found");
                    break;

                case UnauthorizedAccessException _:
                    httpStatusCode = HttpStatusCode.Unauthorized;
                    result = GetErrorMessage("You are not authorized to access this resource.");
                    break;

                case Exception ex:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = GetErrorMessage("Internal server error occurred contact development team.");
                    break;

            }
            context.Response.StatusCode = (int)httpStatusCode;

            return context.Response.WriteAsync(result);
        }

        private string GetErrorMessage(string message)
        {
            var response = new Model.Response<string>();
            response.Succeeded = false;
            response.Errors = new List<string>();
            response.Errors.Add(message);
            return JsonConvert.SerializeObject(response);

        }

    }



    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class GlobalExceptionHandlerExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionHandler>();
        }
    }
}
