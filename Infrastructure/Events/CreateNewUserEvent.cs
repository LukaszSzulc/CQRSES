using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Events
{
    using Domain.Events;

    using Infrastructure.Messages;

    using Raven.Client.Document;

    public class CreateNewUserEvent : IEventHandler<AccountUpdateEvent>
    {
        public void Handle(IEvent<AccountUpdateEvent> @event)
        {
            using (var store = new DocumentStore { Url = "http://localhost:8080", DefaultDatabase = "ES" })
            {
                store.Initialize();
                using (var session = store.OpenSession())
                {
                    session.Store(@event.EventObject);
                    session.SaveChanges();
                }
            }
        }
    }
}
