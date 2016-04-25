namespace Infrastructure.Events
{
    using Domain.Events;

    using Messages;


    public interface IEventHandler
    {
        
    }

    public interface IEventHandler<T> : IEventHandler
        where T : IEvent
    {
        void Handle(IEvent<T> @event);
    }
}
