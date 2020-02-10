using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class AccountDto // Data Transfer Object
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string AccountType { get; set; }
        public Guid OwnerId { get; set; }
    }
}
