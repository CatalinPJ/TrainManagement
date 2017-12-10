using Data.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Data.Domain.Interfaces
{
    public interface ITicketRepository
    {
        IReadOnlyList<Ticket> GetTickets();
        void CreateTicket(Ticket ticket);
        void DeleteTicket(Ticket ticketId);
        void EditTicket(Ticket ticket);
        Ticket GetTicketById(Guid ticketId);
    }
}
