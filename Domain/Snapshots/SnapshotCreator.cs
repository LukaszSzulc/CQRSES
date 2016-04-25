namespace Domain.Snapshots
{
    using System;

    public class SnapshotCreator : ISnapshotCreator
    {
        public UserAggregateSnapshot SnapCreateSnapshot(UserAggregate aggregate, DateTime to)
            => new UserAggregateSnapshot { DateTo = to, UserAggregate = aggregate };

        public Snapshot CreateRootSnapshot(string userId)
        {
            return new Snapshot { Id = $"{userId}/Snapshots",UserId = userId};
        }
    }
}