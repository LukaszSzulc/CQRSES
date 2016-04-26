namespace Infrastructure.Resolver
{
    using Autofac;

    public class DependencyResolver : IDependencyResolver
    {
        private readonly IContainer container;

        public DependencyResolver(IContainer container)
        {
            this.container = container;
        }

        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }
    }
}