using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    using Raven.Client;

    public interface IRavenStore
    {
        IDocumentStore CreateStore<T>(
            string url = "http://localhost:8080",
            string databaseName = "DefaultDatabase",
            bool runInMemory = false);
    }

    public class RavenStore : IRavenStore
    {
        public IDocumentStore CreateStore<T>(
            string url = "http://localhost:8080",
            string databaseName = "DefaultDatabase",
            bool runInMemory = false)
        {
            throw new NotImplementedException();
        }
    }
}
