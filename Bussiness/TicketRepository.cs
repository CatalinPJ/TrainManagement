using Data.Domain.Interfaces;
using System;
using System.Collections.Generic;
using Data.Domain.Entities;

namespace Bussiness
{
    public class TicketRepository : ITicketRepository
    {
        public void CreateTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public void DeleteTicket(Ticket ticketId)
        {
            throw new NotImplementedException();
        }

        public void EditTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Ticket GetTicketById(Guid ticketId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Ticket> GetTickets()
        {
            throw new NotImplementedException();
        }
    }
}
