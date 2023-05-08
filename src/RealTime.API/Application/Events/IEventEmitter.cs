namespace RealTime.API.Application.Events;
public interface IEventEmitter
{
    Task GenerateEventsAsync();
}
