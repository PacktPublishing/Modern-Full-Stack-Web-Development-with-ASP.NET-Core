namespace Chapter03.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;

        }

        public async Task InvokeAsync(HttpContext context)
        {
            try

            {

                await _next(context);

            }

            catch (Exception ex)

            {

                context.Response.StatusCode = 500;

                await context.Response.WriteAsync("An unexpected error occurred.");

                // Log the exception details here 

            }
        }

    }
}
