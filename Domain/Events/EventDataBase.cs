namespace Domain.Events
{
    using System;

    public abstract class EventDataBase
    {
        public DateTime OccuredDate { get; set; }

        public string Description { get; set; }
    }
}