namespace Infrastructure.IOC
{
    using Autofac;

    using Domain.Events;

    using Bus;
    using Commands;
    using Commands.Handlers;
    using Dal;
    using Events;
    using Resolver;

    public class BackendModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServiceBus>().As<IServiceBus>();
            builder.RegisterType<UserDal>().As<IUserDal>();
            builder.RegisterType<AddNewUserHandler>().As<ICommandHandler<CreateNewUserMessage>>();
            builder.RegisterType<UpdateAccountAmmountHandler>().As<ICommandHandler<UpdateAccountAmmountMessage>>();
            builder.RegisterType<CreateSnapshotMessage>().As<ICommandHandler<CreateSnapshotMessage>>();
            builder.RegisterType<CreateNewUserEventHandler>().As<IEventHandler<AccountUpdateEvent>>();
            builder.RegisterType<UpdateAccountAmmountEventHandler>().As<IEventHandler<AmmountUpdateTransferEvent>>();
            builder.RegisterType<DependencyResolver>().As<IDependencyResolver>();
            base.Load(builder);
        }
    }
}
