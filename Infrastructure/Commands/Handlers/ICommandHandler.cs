namespace Infrastructure.Commands.Handlers
{
    interface ICommandHandler
    {
         
    }
    interface ICommandHandler<T>:ICommandHandler where T:ICommand
    {
        void Handle(T message);
    }
}
