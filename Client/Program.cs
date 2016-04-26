using System;

namespace Client
{
    using Infrastructure.Commands;
    using Infrastructure.Messages;

    class Program
    {
        static void Main(string[] args)
        {
            var createNewUserMessage = new Message<CreateNewUserMessage>();
            createNewUserMessage.Content = new CreateNewUserMessage
            {
                StartAmmount = 1000m,
                FirstName = "Lukasz",
                LastName = "Szulc",
                AccountNumber = "1234567890"
            };

            var createSnapshot = new Message<CreateSnapshotMessage>
            {
                Content =
                                             new CreateSnapshotMessage
                                             {
                                                 AccountNumber
                                                         =
                                                         "1234567890",
                                                 To =
                                                         DateTime
                                                         .Now
                                             }
            };
            var updateUserAccountMessage = new Message<UpdateAccountAmmountMessage>
            {
                Content = new UpdateAccountAmmountMessage
                {
                    Ammount = 100m,
                    AccountNumber = "1234567890"
                }
            };
        }
    }
}
