namespace Infrastructure.Commands.Handlers
{
    using System.Linq;

    using Domain;
    using Domain.Events;

    using Bus;
    using Messages;

    using Raven.Client;
    using Raven.Client.Document;

    public class UpdateAccountAmmountHandler : ICommandHandler<UpdateAccountAmmountMessage>
    {
        private readonly IServiceBus serviceBus;

        public UpdateAccountAmmountHandler(IServiceBus serviceBus)
        {
            this.serviceBus = serviceBus;
        }

        public void Handle(UpdateAccountAmmountMessage message)
        {
            using (IDocumentStore store = new DocumentStore { Url = "http://localhost:8080" ,DefaultDatabase = "ES"})
            {
                store.Initialize();
                using (var session = store.OpenSession())
                {
                    var user =
                        session.Query<User>().FirstOrDefault(x => x.AccountNumber == message.AccountNumber);
                    var @event = CreateEvent(user.Id, message.Ammount);
                    serviceBus.PublishEvent(@event);
                }
            }
        }

        private IEvent<AmmountUpdateTransferEvent> CreateEvent(string userId, decimal ammount)
        {
            return new Event<AmmountUpdateTransferEvent>
                       {
                           UserId = userId,
                           EventObject =
                               new AmmountUpdateTransferEvent
                                   {
                                       Ammount = ammount
                                   }
                       };
        } 

    }
}
