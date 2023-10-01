using System.Net;
using System.Text.Json;
using Ecommerce.Product.Domain.Exception;

namespace Ecommerce.Product.Api.Middlewares;

public class GlobalErrorHandlingMiddleware:IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = error switch
            {
                DomainException e => (int)HttpStatusCode.BadRequest,
                NotFoundException e => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError
            };
            await response.WriteAsJsonAsync(new { message = error.Message });
        }
    }
}