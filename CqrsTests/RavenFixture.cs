using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsTests
{
    using Autofac;

    using global::CqrsTests.Listeners;

    using Raven.Client;
    using Raven.Client.Document;
    using Raven.Client.Embedded;

    public class RavenFixture : IDisposable
    {
        private IDocumentStore store;

        private IDocumentSession session;

        public RavenFixture()
        {
            store = new EmbeddableDocumentStore { RunInMemory = true, DefaultDatabase = "TestDatabase"};
            store.Initialize();
            session = store.OpenSession();
        }

        public void Dispose()
        {
            session.Dispose();
            store.Dispose();
        }
    }
}
