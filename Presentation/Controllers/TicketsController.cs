using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Domain.Entities;
using Data.Persistance;
using Services;
using AutoMapper;
using Presentation.DTOs;

namespace Presentation.Controllers
{
    public class TicketsController : Controller
    {
        private readonly DatabaseContext _context;

        public TicketsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tickets.ToListAsync());
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .SingleOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }
        
        public async Task<IActionResult> GetRoute(string originStationName, string destinationStationName, TimeSpan leavingAfter, string primaryStations)
        {
            RouteFinder routeFinder = new RouteFinder(_context);
            List<Train> trains = routeFinder.GetTrains(originStationName, destinationStationName, leavingAfter);
            ViewBag.originStationName = originStationName;
            ViewBag.destinationStationName = destinationStationName;
            ViewBag.primaryStations = primaryStations;
            return View(trains);
            //return View(ticket);
        }

        public IActionResult Create(Guid trainId, string from, string to)
        {
            Train train = _context.Trains.Include("RouteNodes")
             .FirstOrDefault(m => m.Id == trainId);
            var source = new TicketDTO()
            {
                OriginStationName = from,
                DestinationStationName = to,
                DepartureTime = train.RouteNodes.FirstOrDefault(o=>o.OriginStationName == from).DepartureTime,
                ArrivalTime = train.RouteNodes.FirstOrDefault(o => o.OriginStationName == to).ArrivalTime,
                TrainCategory = train.Category,
                TrainNumber = train.OfficialNumber,
                TrainId = train.Id,
                DepartureDate = DateTime.Now
            };
            ViewBag.from = from;
            ViewBag.to = to;
            return View(source);
        }
        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TicketDTO ticketDTO, string to, string from, Guid trainId)
        {
            Train train = _context.Trains.Include("RouteNodes")
             .FirstOrDefault(m => m.Id == trainId);
            var source = new TicketDTO()
            {
                OriginStationName = from,
                DestinationStationName = to,
                DepartureTime = train.RouteNodes.FirstOrDefault(o => o.OriginStationName == from).DepartureTime,
                ArrivalTime = train.RouteNodes.FirstOrDefault(o => o.OriginStationName == to).ArrivalTime,
                TrainCategory = train.Category,
                TrainNumber = train.OfficialNumber,
                TrainId = train.Id,
                DepartureDate = DateTime.Now
            };
            source.Adults = ticketDTO.Adults;
            source.Students = ticketDTO.Students;
            source.Children = ticketDTO.Children;
            source.Pet = ticketDTO.Pet;
            source.Class = ticketDTO.Class;
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<TicketDTO, Ticket>();
            });
            IMapper mapper = config.CreateMapper();
            var ticket = mapper.Map<TicketDTO, Ticket>(source);
            PriceComputer priceComputer = new PriceComputer();
            int from_id = train.RouteNodes.FirstOrDefault(o => o.OriginStationName == from).OfficialCode;
            int to_id = train.RouteNodes.FirstOrDefault(o => o.OriginStationName == to).OfficialCode;
            List<RouteNode> nodes = train.RouteNodes.Where(o => o.OfficialCode >= from_id && o.OfficialCode <= to_id).ToList();
            int distance = 0;
            foreach (var node in nodes)
                distance += node.Km / 1000;
            ticket.Km = distance;
            ticket.Price = (int)priceComputer.GetPrice(ticket);
            ticket.Email = "petronel.catalin@gmail.com";
            _context.Add(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets.SingleOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,TrainId,UserId,OriginStationId,DestinationStationId,DepartureTime,ArrivalTime,Duration,Km,Type,Pet,Bike,Car,Seat,Price")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .SingleOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ticket = await _context.Tickets.SingleOrDefaultAsync(m => m.Id == id);
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(Guid id)
        {
            return _context.Tickets.Any(e => e.Id == id);
        }
    }
}
