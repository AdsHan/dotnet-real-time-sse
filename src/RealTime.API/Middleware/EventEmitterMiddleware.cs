namespace RealTime.API.Middleware;

public class EventEmitterMiddleware
{
    private readonly RequestDelegate _next;

    public EventEmitterMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {

        if (context.Request.Path.ToString().Equals("/api/events/middleware"))
        {
            var response = context.Response;

            response.Headers.Add("Content-Type", "text/event-stream");
            response.Headers.Add("Cache-Control", "no-cache");
            response.Headers.Add("Access-Control-Allow-Origin", "*");

            while (true)
            {
                string data = "Via Middleware " + DateTime.Now.ToString();
                string sseEvent = $"data: {data}\n\n";

                await response.WriteAsync(sseEvent);
                await response.Body.FlushAsync();

                await Task.Delay(3000);
            }

        }

        await _next.Invoke(context);
    }
}
