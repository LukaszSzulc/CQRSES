namespace Infrastructure.Commands
{
    public class UpdateAccountAmmountMessage : ICommand
    {
        public decimal Ammount { get; set; }

        public string AccountNumber { get; set; }
    }
}
