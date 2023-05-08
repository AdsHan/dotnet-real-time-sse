using Microsoft.AspNetCore.Mvc;
using RealTime.API.Application.Events;

namespace RealTime.API.Controllers;

[Route("api/events")]
[ApiController]
public class EventEmitterController : ControllerBase
{

    private readonly IEventEmitter _emitter;

    public EventEmitterController(IEventEmitter emitter)
    {
        _emitter = emitter;
    }

    // Get api/events/controller
    [HttpGet("controller")]
    public async Task<IActionResult> GetStreamAsync()
    {
        await _emitter.GenerateEventsAsync();

        return Ok();
    }
}
