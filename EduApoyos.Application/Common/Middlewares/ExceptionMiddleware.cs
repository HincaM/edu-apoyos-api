using EduApoyos.Application.Common.Exceptions;
using EduApoyos.Application.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace EduApoyos.Application.Common.Middlewares
{
    public sealed class ExceptionMiddleware(ILogger<ExceptionMiddleware> _logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next(context);
			}
			catch (ValidationException ve)
            {
                await BuildExceptionFluentValidation(context, ve);
            }
            catch (ErrorOrException eoe)
            {
                await BuildExceptionErrorOr(context, eoe);
            }
            catch (Exception ex)
            {
                await BuildExceptionGlobal(context, ex);
            }
        }
        
        private async Task BuildExceptionFluentValidation(HttpContext context, ValidationException ve)
        {
            var errors = ve.Errors.GroupBy(gb => gb.PropertyName, e => e.ErrorMessage).ToDictionary(key => key.Key, value => value.ToArray());
            var statusCode = (int)HttpStatusCode.BadRequest;

            var modelState = new ModelStateDictionary();
            foreach (var item in errors)
            {
                foreach (var error in item.Value)
                {
                    modelState.AddModelError(item.Key, error);
                }
            }

            var problemDetails = new ValidationProblemDetails(modelState)
            {
                Status = statusCode,
                Title = "Error de validación",
                Detail = "Uno o más errores de validación han ocurrido."
            };

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var json = JsonSerializer.Serialize(problemDetails);
            await context.Response.WriteAsync(json);
        }

        private async Task BuildExceptionErrorOr(HttpContext context, ErrorOrException eoe)
        {
            _logger.LogError(string.Join("\n\n", eoe.Errors.SelectMany(s => $"{s.Key} - {s.Value}")));

            var statusCode = (int)(eoe.Errors.First().Key switch
            {
                ErrorType.Unauthorized => HttpStatusCode.Unauthorized,
                ErrorType.Validation => HttpStatusCode.BadRequest,
                ErrorType.NotFound => HttpStatusCode.NotFound,
                _ => HttpStatusCode.BadRequest
            });

            var modelState = new ModelStateDictionary();
            foreach (var item in eoe.Errors)
            {
                foreach (var error in item.Value)
                {
                    modelState.AddModelError(item.Key.ToString(), error);
                }
            }

            var problemDetails = new ValidationProblemDetails(modelState)
            {
                Status = statusCode,
                Title = "Error de validación",
                Detail = "Uno o más errores de validación han ocurrido."
            };

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var json = JsonSerializer.Serialize(problemDetails);
            await context.Response.WriteAsync(json);
        }

        private async Task BuildExceptionGlobal(HttpContext context, Exception ex)
        {
            _logger.LogError(ex, "Ocurrió un error no controlado.");
            var statusCode = (int)HttpStatusCode.InternalServerError;

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = "Error interno del servidor",
                Detail = ExceptionExtensions.GetInnerException(ex)
            };

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var json = JsonSerializer.Serialize(problemDetails);
            await context.Response.WriteAsync(json);
        }
    }
}
