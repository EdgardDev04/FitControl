using FluentValidation;
using FitControl.WebAPI.Responses;

namespace FitControl.WebAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context) 
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error");

                var errors = ex.Errors.Select(e => new
                {
                    Field = e.PropertyName,
                    Error = e.ErrorMessage
                });

                await HandleException(context, StatusCodes.Status400BadRequest, "Validation error", ex.Errors);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Resource not found");

                await HandleException(context, StatusCodes.Status404NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred");

                await HandleException(context, StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        private async Task HandleException(HttpContext context, int statusCode, string message, object? errors = null)
        {
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var response = new ApiResponse<object>
            {
                Success = false,
                StatusCode = statusCode,
                Message = message,
                Data = errors,
                TraceId = context.TraceIdentifier,
                Path = context.Request.Path
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
