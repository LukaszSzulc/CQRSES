namespace Infrastructure.Dal
{
    using System;

    using Domain;

    public interface IUserDal : IDisposable
    {
        UserAggregate GetUserInfo(string accountNumber);

        UserAggregate GetUserInfoFromSpan(string accountNumber, TimeSpan span);

        UserAggregate GetFromSnapshot(string accountNumber);

        UserAggregate GetFromSnapshotSpan(string accountNumber, TimeSpan span);
    }
}
