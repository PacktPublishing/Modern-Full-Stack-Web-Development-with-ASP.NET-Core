namespace Chapter03.Middlewares
{
    public class CustomLoggingMiddleware
    {

        private readonly RequestDelegate _next;

        public CustomLoggingMiddleware(RequestDelegate next)
        {

            _next = next;

        }

        public async Task InvokeAsync(HttpContext context)
        {

            // Log the request path 

            Console.WriteLine($"Request URL: {context.Request.Path.Value}");

            await _next(context);
        }

    }
}
