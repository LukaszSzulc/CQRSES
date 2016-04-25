namespace Domain.Snapshots
{
    using System;

    using Domain;

    public interface ISnapshotCreator
    {
        UserAggregateSnapshot SnapCreateSnapshot(UserAggregate aggregate, DateTime to);

        Snapshot CreateRootSnapshot(string userId);
    }
}
