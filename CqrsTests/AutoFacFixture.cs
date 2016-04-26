using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsTests
{
    using Autofac;

    using Infrastructure.IOC;

    public class AutoFacFixture : IDisposable
    {
        public IContainer container { get; }
        public AutoFacFixture()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<BackendModule>();
            container = builder.Build();
        }

        public void Dispose()
        {
            container.Dispose();
        }
    }
}
