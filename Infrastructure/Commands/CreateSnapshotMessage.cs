using System;
namespace Infrastructure.Commands
{
    public class CreateSnapshotMessage : ICommand
    {
        public DateTime To { get; set; }

        public string AccountNumber { get; set; }
    }
}
