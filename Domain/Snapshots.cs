namespace Domain
{
    using System.Collections.Generic;

    public class Snapshot
    {
        public Snapshot()
        {
            Snapshots = new List<UserAggregateSnapshot>();
        }
        public string Id { get; set; }

        public string UserId { get; set; }

        public List<UserAggregateSnapshot> Snapshots { get; set; }
    }
}