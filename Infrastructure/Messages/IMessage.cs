namespace Infrastructure.Messages
{
    public interface IMessage<T>
    {
        T Content { get; set; }
    }
}
