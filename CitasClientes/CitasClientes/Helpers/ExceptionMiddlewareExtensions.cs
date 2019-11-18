using CitasClientes.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Authentication;

namespace CitasClientes.Helpers
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = (int)GetErrorCode(contextFeature.Error),
                            Message = contextFeature.Error.Message
                        }.ToString());
                    }
                });
            });
        }
        private static HttpStatusCode GetErrorCode(Exception e)
        {
            switch (e)
            {
                case ValidationException _:
                    return HttpStatusCode.BadRequest;
                case AuthenticationException _:
                    return HttpStatusCode.Forbidden;
                case NotImplementedException _:
                    return HttpStatusCode.NotImplemented;
                default:
                    return HttpStatusCode.InternalServerError;
            }
        }
    }
}
