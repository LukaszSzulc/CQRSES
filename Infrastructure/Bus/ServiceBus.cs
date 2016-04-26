namespace Infrastructure.Bus
{
    using System;
    using System.Collections.Generic;

    using Domain.Events;

    using Commands;
    using Commands.Handlers;
    using Events;

    using Infrastructure.Resolver;

    using Messages;

    public class ServiceBus : IServiceBus
    {
        private readonly IDependencyResolver resolver;

        public ServiceBus(IDependencyResolver resolver)
        {
            this.resolver = resolver;
        }

        public void Send<T>(IMessage<T> message) where T : ICommand
        {
            var commandHandler = resolver.Resolve<ICommandHandler<T>>();
            commandHandler.Handle(message.Content);
        }

        public void PublishEvent<T>(IEvent<T> @event) where T:IEvent
        {
            var eventHandler = resolver.Resolve <IEventHandler<T>>();
            eventHandler.Handle(@event);
        }
    }
}