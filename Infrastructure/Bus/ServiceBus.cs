namespace Infrastructure.Bus
{
    using System;
    using System.Collections.Generic;

    using Domain.Events;

    using Commands;
    using Commands.Handlers;
    using Events;

    using Messages;

    public class ServiceBus : IServiceBus
    {
        private Dictionary<Type, Func<ICommandHandler>> handlers;

        private Dictionary<Type, Func<IEventHandler>> eventHandlers; 

        public ServiceBus()
        {
            InitializeHandlers();
        } 

        public void Send<T>(IMessage<T> message) where T : ICommand
        {
            var commandHandler = (ICommandHandler<T>)handlers[typeof(ICommandHandler<>).MakeGenericType(typeof(T))]();
            commandHandler.Handle(message.Content);

        }

        public void PublishEvent<T>(IEvent<T> @event) where T:IEvent
        {
            var eventHandler = (IEventHandler<T>)eventHandlers[typeof(IEventHandler<>).MakeGenericType(typeof(T))]();
            eventHandler.Handle(@event);
        }

        private void InitializeHandlers()
        {
            handlers = new Dictionary<Type, Func<ICommandHandler>>();
            eventHandlers = new Dictionary<Type, Func<IEventHandler>>();
            handlers.Add(typeof(ICommandHandler<CreateNewUserMessage>), () => new AddNewUserHandler());
            handlers.Add(typeof(ICommandHandler<UpdateAccountAmmountMessage>), () => new UpdateAccountAmmountHandler());
            handlers.Add(typeof(ICommandHandler<CreateSnapshotMessage>), () => new CreateSnapshotHandler());
            eventHandlers.Add(typeof(IEventHandler<AmmountUpdateTransferEvent>), () => new UpdateAccountAmmountEventHandler());
            eventHandlers.Add(typeof(IEventHandler<AccountUpdateEvent>), () => new CreateNewUserEvent());
        }
    }
}