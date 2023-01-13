
using Microsoft.Extensions.Options;
using PersonalProject.Common;

namespace PersonalProject.Client.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _settings;

        public ErrorHandlerMiddleware(RequestDelegate next, IOptions<AppSettings> settings)
        {
            _next = next;
            _settings = settings.Value;
        }

        public async Task Invoke(HttpContext context){
            await _next(context);
            int statusCode = context.Response.StatusCode;
            string message = GetDefaultMessageForStatus(statusCode);
            if(statusCode == StatusCodes.Status403Forbidden || statusCode == StatusCodes.Status401Unauthorized)
                context.Response.Redirect($"{context.Request.Scheme}://{context.Request.Host}/Error/Index?statusCode={statusCode}%20-%20{message}&errorMessage=You%20are%20trying%20to%20access%20an%20unauthorized%20site");
        }

        public string GetDefaultMessageForStatus(int statusCode){
            switch(statusCode){
                case 403:
                    return "Forbidden";
                case 401:
                    return "Unauthorized";
                default:
                    return "Unidentified Error";
            }
        }
    }
}