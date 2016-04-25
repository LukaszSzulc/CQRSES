namespace Domain
{
    using System;

    public class UserAggregateSnapshot
    {
        public DateTime DateTo { get; set; }

        public UserAggregate UserAggregate { get; set; }
    }
}