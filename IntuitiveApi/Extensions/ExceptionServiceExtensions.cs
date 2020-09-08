using System;
using System.Net;
using IntuitiveApi.Error;
using IntuitiveApi.Models;
using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace IntuitiveApi.Extensions
{
    public static class ExceptionServiceExtensions
    {
      /*  public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerManager logger)
        {
             app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if(contextFeature != null)
                    { 
                        logger.LogError($"Something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
        {
            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error."
                        }.ToString());
                    }
});
            });
        }*/
        public static void CustomException(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomError>();
        }


    }
}
