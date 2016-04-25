namespace Domain
{
    using System.Collections.Generic;

    using Domain.Events;

    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AccountNumber { get; set; }
    }
}
