namespace Infrastructure.Commands.Handlers
{
    using System;
    using System.Linq;

    using Domain;
    using Domain.Snapshots;

    using Infrastructure.Dal;

    using Raven.Client.Document;

    public class CreateSnapshotHandler : ICommandHandler<CreateSnapshotMessage>
    {
        public void Handle(CreateSnapshotMessage message)
        {
            IUserDal dal = new UserDal();
            ISnapshotCreator creator = new SnapshotCreator();
            var aggregate = dal.GetUserInfoFromSpan(message.AccountNumber, DateTime.Now - message.To);
            var snapshot = creator.SnapCreateSnapshot(aggregate, message.To);
            using (var store = new DocumentStore { Url = "http://localhost:8080", DefaultDatabase = "ES" })
            {
                store.Initialize();
                using (var session = store.OpenSession())
                {
                    var user = session.Query<User>().FirstOrDefault(x => x.AccountNumber == message.AccountNumber);
                    var snapShot = session.Load<Snapshot>($"{user.Id}/Snapshots");
                    snapShot.Snapshots.Insert(0,snapshot);
                    session.SaveChanges();
                }
            }
        }

      
    }
}
