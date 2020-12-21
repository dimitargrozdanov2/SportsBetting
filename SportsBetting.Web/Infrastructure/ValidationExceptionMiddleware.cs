using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SportsBetting.Data.Exceptions;
using System;
using System.Threading.Tasks;

namespace SportsBetting.Web.Infrastructure
{
    public class ValidationExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public ValidationExceptionHandlerMiddleware(RequestDelegate next)
            => this.next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next(context);

                if (context.Response.StatusCode == 404)
                {
                    context.Response.Redirect("/error/pagenotfound");
                }
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var result = string.Empty;

            switch (exception)
            {
                case EntityExistsException ex:
                    context.Response.Redirect($"/Error/Alreadyexistserror?error={ex.Message}");
                    break;
                case NotFoundException _:
                    context.Response.Redirect($"/Error/PageNotFound");
                    break;
                case BadRequestException ex:
                    context.Response.Redirect($"/Error/Invalid?error={ex.Message}");
                    break;
            }

            if (String.IsNullOrEmpty(result))
            {
                context.Response.Redirect($"/Error/BadRequestPage");

            }
            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(result);
        }

        private static string SerializeObject(object obj)
            => JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy(true, true)
                }
            });
    }
}
