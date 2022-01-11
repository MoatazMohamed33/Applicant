using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Applicant.Application.Common.Responses
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseFluentValidationExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(x =>
            {
                x.Run(async context =>
                {
                    string errorText = "";
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = errorFeature.Error;
                    if (exception.GetType() == typeof(ValidationException))
                    {
                        var validationException = (ValidationException)exception;
                        var response = new OutputResponseForValidationFilter
                        {
                            Message = "One or more validation failures have occurred.",
                            StatusCode = HttpStatusCode.BadRequest,
                            Success = false,
                            Model = null,
                            Errors = validationException.Errors.Select(err => new ErrorModel()
                            {
                                ErrorCode = err.ErrorCode,
                                Message = err.ErrorMessage,
                                Property = err.PropertyName
                            }).ToList()
                        };
                        errorText = JsonSerializer.Serialize(response, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    }
                    else
                    {
                        var response = new OutputResponse<string>
                        {
                            Message = exception.InnerException.Message,
                            StatusCode = HttpStatusCode.BadRequest,
                            Success = false,
                            Model = null,
                        };
                        errorText = JsonSerializer.Serialize(response, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                    }
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(errorText, Encoding.UTF8);
                });
            });
        }
    }
}
