using System;
using System.Net;
using System.Threading.Tasks;
using IntuitiveApi.Models;
using LoggerService;
using Microsoft.AspNetCore.Http;

namespace IntuitiveApi.Error
{
    public class CustomError
    {
        private readonly RequestDelegate _incomingrequest;
        private readonly ILoggerManager _logger;

        public CustomError(RequestDelegate incomingrequest, ILoggerManager logger)
        {
            _logger = logger;
            _incomingrequest = incomingrequest;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _incomingrequest(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error."
            }.ToString());
        }
    }
}
