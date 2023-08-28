using DI.Services;

namespace DI.Middleware
{
    public class TestMiddleware: IMiddleware
    {
        public LogService logService { get; set; }
        public TestMiddleware(LogService logService)
        {
            this.logService = logService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            this.logService.Write3("Hello World");
            await next(context);
        }
    }
}
