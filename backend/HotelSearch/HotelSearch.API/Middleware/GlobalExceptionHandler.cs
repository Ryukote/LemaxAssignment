using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace HotelSearch.API.Middleware
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            // Log the exception
            _logger.LogError(
                exception, "An unhandled exception occurred: {Message}", exception.Message);

            switch (exception)
            {
                case KeyNotFoundException:
                    httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
                    {
                        Status = StatusCodes.Status404NotFound,
                        Title = "Resource not found.",
                        Detail = exception.Message
                    }, cancellationToken);
                    break;
            }

            //// Create a user-friendly error response
            //var problemDetails = new ProblemDetails
            //{
            //    Status = (int)HttpStatusCode.InternalServerError,
            //    Title = "An unexpected server error occurred.",
            //    Detail = "We are sorry, something went wrong on our end. Please try again later.",
            //    Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
            //};

            //// Set the response
            //httpContext.Response.StatusCode = problemDetails.Status.Value;
            //await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            //// Return true to indicate that the exception has been handled.
            return true;
        }
    }
}
