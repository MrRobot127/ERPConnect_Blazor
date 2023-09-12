using ERPConnect.Logging;

namespace ERPConnect.Api.Middlewares
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggerMiddleware(RequestDelegate next)
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
                // Log the exception using Logger.Instance
                Logger.Instance.Error("An Exception occurred:", ex);
                throw;
            }
        }
    }
}
