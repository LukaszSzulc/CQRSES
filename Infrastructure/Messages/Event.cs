namespace Infrastructure.Messages
{
    using Domain.Events;

    public class Event<T> : IEvent<T> where T : IEvent
    {
        public string UserId { get; set; }

        public T EventObject { get; set; }
    }
}