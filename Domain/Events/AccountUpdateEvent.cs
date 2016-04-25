namespace Domain.Events
{
    using System.Collections.Generic;

    public class AccountUpdateEvent : IEvent
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string EventType { get; set; }
        public List<AmmountUpdate> Updates { get; set; }
    }
}