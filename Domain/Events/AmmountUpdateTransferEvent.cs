namespace Domain.Events
{
    public class AmmountUpdateTransferEvent : IEvent
    {
        public decimal Ammount { get; set; }
    }
}