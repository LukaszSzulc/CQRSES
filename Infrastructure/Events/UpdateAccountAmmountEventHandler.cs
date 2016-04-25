namespace Infrastructure.Events
{
    using System;
    using System.Linq;

    using Domain.Events;

    using Messages;

    using Raven.Client;
    using Raven.Client.Document;

    public class UpdateAccountAmmountEventHandler : IEventHandler<AmmountUpdateTransferEvent>
    {
        public void Handle(IEvent<AmmountUpdateTransferEvent> @event)
        {
            using (IDocumentStore store = new DocumentStore { Url = "http://localhost:8080", DefaultDatabase = "ES" })
            {
                store.Initialize();
                using (IDocumentSession session = store.OpenSession())
                {
                    var result = session.Query<AccountUpdateEvent>().FirstOrDefault(x => x.UserId == @event.UserId);

                    result.Updates.Insert(0,CreateEvent(@event.EventObject,@event.UserId));
                    session.SaveChanges();
                }
            }
        }

        private AmmountUpdate CreateEvent(AmmountUpdateTransferEvent @event, string userId)
        {
            return new AmmountUpdate
                       {
                           Ammount = @event.Ammount,
                           OccuredDate = DateTime.Now.AddDays(3),
                           Description = $"New Transaction for user {userId}"
                       };
        }
    }
}