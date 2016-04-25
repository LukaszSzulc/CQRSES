using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserAggregate : AggregateRoot
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AccountNumber { get; set; }

        public decimal Ammount { get; set; }

        private UserAggregate()
        {
            
        }

        public static UserAggregate Create(User userInfo, decimal ammount)
        {
            return new UserAggregate
                       {
                           AccountNumber = userInfo.AccountNumber,
                           FirstName = userInfo.FirstName,
                           LastName = userInfo.LastName,
                           Ammount = ammount,
                           Id = userInfo.Id
                       };
        }

    }
}
