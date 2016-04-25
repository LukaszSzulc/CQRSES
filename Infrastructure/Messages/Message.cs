namespace Infrastructure.Messages
{
    public class Message<T> : IMessage<T>
    {
        public T Content { get; set; }
    }
}