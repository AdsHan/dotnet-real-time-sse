namespace RealTime.API.Application.Events;

public class EventEmitter : IEventEmitter
{
    private readonly HttpContext _context;

    public EventEmitter(IHttpContextAccessor accessor)
    {
        _context = accessor.HttpContext;
    }

    public async Task GenerateEventsAsync()
    {
        _context.Response.Headers.Add("Content-Type", "text/event-stream");
        _context.Response.Headers.Add("Cache-Control", "no-cache");
        _context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

        while (true)
        {
            string data = "Via Controller " + DateTime.Now.ToString();
            string sseEvent = $"data: {data}\n\n";

            await _context.Response.WriteAsync(sseEvent);
            await _context.Response.Body.FlushAsync();

            await Task.Delay(3000);
        }
    }
}
