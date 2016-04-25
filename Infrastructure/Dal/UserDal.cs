namespace Infrastructure.Dal
{
    using System;
    using System.Linq;

    using Domain;
    using Domain.Events;

    using Raven.Client;
    using Raven.Client.Document;

    public class UserDal : IUserDal
    {
        private IDocumentStore store;

        private IDocumentSession session;

        public UserDal()
        {
            store = new DocumentStore { Url = "http://localhost:8080", DefaultDatabase = "ES" };
            store.Initialize();
            session = store.OpenSession();
        }
        public UserAggregate GetUserInfo(string accountNumber)
        {
            var user = session.Query<User>().FirstOrDefault(x => x.AccountNumber == accountNumber);
            var ammout = session.Load<AccountUpdateEvent>($"{user.Id}/Events").Updates.Sum(x => x.Ammount);
            return UserAggregate.Create(user, ammout);
        }

        public UserAggregate GetUserInfoFromSpan(string accountNumber, TimeSpan span)
        {
            var user = session.Query<User>().FirstOrDefault(x => x.AccountNumber == accountNumber);
            var ammout =
                session.Load<AccountUpdateEvent>($"{user.Id}/Events")
                    .Updates.Where(x => x.OccuredDate - DateTime.Now <= span)
                    .Sum(x => x.Ammount);
            return UserAggregate.Create(user, ammout);
        }

        public UserAggregate GetFromSnapshot(string accountNumber)
        {
            var user = session.Query<User>().FirstOrDefault(x => x.AccountNumber == accountNumber);
            var snapshot = session.Load<Snapshot>($"{user.Id}/Snapshots").Snapshots.FirstOrDefault();
            var events =
                session.Load<AccountUpdateEvent>($"{user.Id}/Events")
                    .Updates.Where(x => x.OccuredDate > snapshot.DateTo)
                    .Sum(x => x.Ammount);
            snapshot.UserAggregate.Ammount += events;
            return snapshot.UserAggregate;
        }

        public UserAggregate GetFromSnapshotSpan(string accountNumber, TimeSpan span)
        {
            var user = session.Query<User>().FirstOrDefault(x => x.AccountNumber == accountNumber);
            var snapshot =
                session.Load<Snapshot>($"{user.Id}/Snapshots")
                    .Snapshots.FirstOrDefault(x => DateTime.Now - x.DateTo <= span);
            var ammount =
                session.Load<AccountUpdateEvent>($"{user.Id}/Events")
                    .Updates.Where(x => x.OccuredDate > snapshot.DateTo)
                    .Sum(x => x.Ammount);
            snapshot.UserAggregate.Ammount += ammount;
            return snapshot.UserAggregate;
        }

        public void Dispose()
        {
            store.Dispose();
            session.Dispose();  
            store = null;
            session = null;
        }
    }
}