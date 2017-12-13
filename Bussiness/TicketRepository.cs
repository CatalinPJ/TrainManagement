using Data.Domain.Interfaces;
using System;
using System.Collections.Generic;
using Data.Domain.Entities;
using Data.Persistance;
using System.Linq;

namespace Bussiness
{
    public class TicketRepository : ITicketRepository
    {
        private readonly IDatabaseContext _databaseContext;
        public TicketRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public void CreateTicket(Ticket ticket)
        {
            _databaseContext.Tickets.Add(ticket);
            _databaseContext.SaveChanges();
        }

        public void DeleteTicket(Guid ticketId)
        {
            var ticket = GetTicketById(ticketId);
            _databaseContext.Tickets.Remove(ticket);
            _databaseContext.SaveChanges();
        }

        public void EditTicket(Ticket ticket)
        {
            _databaseContext.Tickets.Update(ticket);
            _databaseContext.SaveChanges();
        }

        public Ticket GetTicketById(Guid ticketId)
        {
            return _databaseContext.Tickets.FirstOrDefault(o => o.Id == ticketId);
        }

        public IReadOnlyList<Ticket> GetTickets()
        {
            return _databaseContext.Tickets.ToList();
        }
    }
}
