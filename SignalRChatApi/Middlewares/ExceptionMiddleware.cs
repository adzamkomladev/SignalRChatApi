using SignalRChatApi.Data.Responses;

namespace SignalRChatApi.Middlewares;

public class ExceptionMiddleware : IMiddleware
{

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new BaseResponse
            {
                Success = false,
                Message = e.Message,
            });
        }
    }
}