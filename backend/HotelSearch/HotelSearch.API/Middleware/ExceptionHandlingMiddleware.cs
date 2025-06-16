using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace HotelSearch.API.Middleware
{
    public class ExceptionHandlingMiddleware : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not ValidationException validationException)
            {
                return false; // Let another handler deal with it
            }

            var problemDetails = new ProblemDetails
            {
                Status = (int)HttpStatusCode.BadRequest, // Default to 400
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Title = "A validation error occurred"
            };

            var firstError = validationException.Errors.FirstOrDefault();

            if (firstError != null)
            {
                problemDetails.Status = (int)HttpStatusCode.BadRequest;
                problemDetails.Detail = firstError.ErrorCode;
            }

            httpContext.Response.StatusCode = problemDetails.Status.Value;

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
