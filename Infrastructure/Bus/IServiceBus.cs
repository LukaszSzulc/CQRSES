namespace Infrastructure.Bus
{
    using Domain.Events;

    using Infrastructure.Commands;

    using Messages;

    public interface IServiceBus
    {
        void Send<T>(IMessage<T> message) where T : ICommand;

        void PublishEvent<T>(IEvent<T> @event) where T : IEvent;
    }
}
