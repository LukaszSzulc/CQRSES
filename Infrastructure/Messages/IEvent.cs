namespace Infrastructure.Messages
{
    using Domain.Events;
    public interface IEvent<T> where T : IEvent
    {
         string UserId { get; set; }
         T EventObject { get; set; }
    }
}
