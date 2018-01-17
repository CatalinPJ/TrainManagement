using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Domain.Entities
{
    public class Payment
    {
        public Payment()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public Guid UserId { get; set; }
        public string BankName { get; set; }
    }
}
