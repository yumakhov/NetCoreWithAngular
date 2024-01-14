using System.Net.Mime;

namespace NetCoreWithAngular.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next) 
        { 
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var response = ex switch
            {
                KeyNotFoundException => new ExceptionResponse(StatusCodes.Status400BadRequest, ex.Message),
                _ => new ExceptionResponse(StatusCodes.Status400BadRequest, "Internal server error")
            };

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(response);
        }

        private record ExceptionResponse(int StatusCode, string ErrorDetails);
    }
}
