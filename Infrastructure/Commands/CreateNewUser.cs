namespace Infrastructure.Commands
{
    public class CreateNewUserMessage : ICommand
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AccountNumber { get; set; }

        public decimal StartAmmount { get; set; }
    }
}
