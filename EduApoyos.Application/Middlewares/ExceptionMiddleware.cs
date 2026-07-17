using EduApoyos.Application.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace EduApoyos.Application.Middlewares
{
    public sealed class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next(context);
			}
			catch (ValidationException ve)
			{
			}
            catch (ErrorOrException eoe)
            {
            }
            catch (Exception ex)
            {
            }
        }
    }
}
