using DotnetAngularWebProject.Common.API;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using System.Threading.Tasks;

namespace DotnetAngularWebProject.Host.Middleware {
    public class JsonExceptionPage {
        private readonly RequestDelegate next;

        public JsonExceptionPage(RequestDelegate next) => this.next = next;

        public async Task Invoke(HttpContext httpContext, IWebHostEnvironment env) {
            try {
                await next(httpContext);
            }
            catch (ApiException e) {
                await ApiErrorResponse(httpContext, e, env);
            }
            catch (Exception e) {
                await UnknownErrorResponse(httpContext, e, env);
            }
        }

        private static Task ApiErrorResponse(HttpContext httpContext, ApiException e, IWebHostEnvironment env) {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)e.ErrorCode;

            return httpContext
                .Response
                .WriteAsJsonAsync(BuildErrorResponse(e.ErrorCode, e, env));
        }

        private static Task UnknownErrorResponse(HttpContext httpContext, Exception e, IWebHostEnvironment env) {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return httpContext
                .Response
                .WriteAsJsonAsync(BuildErrorResponse(HttpStatusCode.InternalServerError, e, env));
        }

        private static ErrorResponse BuildErrorResponse(HttpStatusCode httpStatus, Exception e, IWebHostEnvironment env) {
            ErrorDto error = new() {
                Code = (int)httpStatus,
                Type = httpStatus.ToString(),
                Message = e.Message,
            };

            return env.IsDevelopment()
                ? new ErrorResponse {
                    Error = error,
                    Exception = ExceptionDto.From(e),
                }
                : new ErrorResponse {
                    Error = error,
                };
        }
    }

    public static class JsonExceptionPageMiddlewareExtensions {
        public static IApplicationBuilder UseJsonExceptionPage(this IApplicationBuilder builder)
            => builder.UseMiddleware<JsonExceptionPage>();
    }
}
