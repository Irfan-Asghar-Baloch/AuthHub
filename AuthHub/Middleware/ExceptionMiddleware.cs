using System.Net;
using System.Threading.Tasks;

namespace AuthHub.API.MiddleWare
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
          _next = next;  
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }catch(Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";  
                var response = new
                {
                    Status = 500,
                    Message = "Internal Server Error from the custom middleware.",
                    Detailed = ex.Message
                };

await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
