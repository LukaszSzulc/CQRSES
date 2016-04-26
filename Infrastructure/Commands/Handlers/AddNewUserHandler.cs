namespace Infrastructure.Commands.Handlers
{
    using System;

    using Domain;
    using Domain.Events;

    using System.Collections.Generic;

    using Domain.Snapshots;

    using Bus;
    using Messages;

    using Raven.Client;
    using Raven.Client.Document;

    public class AddNewUserHandler : ICommandHandler<CreateNewUserMessage>
    {
        private readonly IServiceBus serviceBus;

        public AddNewUserHandler(IServiceBus serviceBus)
        {
            this.serviceBus = serviceBus;
        }

        public void Handle(CreateNewUserMessage message)
        {
            ISnapshotCreator snapshotCreator = new SnapshotCreator();
            using (IDocumentStore store = new DocumentStore { Url = "http://localhost:8080", DefaultDatabase = "ES" })
            {
                store.Initialize();
                var userObject = MapToUserObject(message);
                using (var session = store.OpenSession())
                {
                    session.Store(userObject);
                    session.Store(snapshotCreator.CreateRootSnapshot(userObject.Id));
                    session.SaveChanges();
                    var @event = InitialAmmountEvent(userObject, message);
                    serviceBus.PublishEvent(@event);
                }
            }
        }

        private User MapToUserObject(CreateNewUserMessage message)
        {
            return new User
                       {
                           FirstName = message.FirstName,
                           AccountNumber = message.AccountNumber,
                           LastName = message.LastName
                       };
        }

        private IEvent<AccountUpdateEvent> InitialAmmountEvent(User user, CreateNewUserMessage message)
        {
            return new Event<AccountUpdateEvent>
                       {
                           EventObject =
                               new AccountUpdateEvent
                                   {
                                       Id = user.Id +"/Events",
                                       UserId = user.Id,
                                       EventType =
                                           typeof(AccountUpdateEvent).Name,
                                       Updates =
                                           new List<AmmountUpdate>
                                               {
                                                   new AmmountUpdate
                                                       {
                                                           Ammount
                                                               =
                                                               message
                                                               .StartAmmount,
                                                           Description
                                                               =
                                                               $"Initial ammout for client {message.FirstName} {message.LastName} {message.AccountNumber}",
                                                           OccuredDate
                                                               =
                                                               DateTime
                                                               .Now
                                                       }
                                               }
                                   }
                       };
        }
    }
}
