using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Domain.Entities;
using Data.Persistance;

namespace Presentation.Controllers
{
    public class RouteNodesController : Controller
    {
        private readonly DatabaseContext _context;

        public RouteNodesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: RouteNodes
        public async Task<IActionResult> Index()
        {
            return View(await _context.RouteNodes.ToListAsync());
        }

        // GET: RouteNodes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routeNode = await _context.RouteNodes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (routeNode == null)
            {
                return NotFound();
            }

            return View(routeNode);
        }

        // GET: RouteNodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RouteNodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RouteId,Name,OfficialCode,DestinationStationCode,OriginStationCode,DestinationStationName,OriginStationName,Km,DepartureTime,ArrivalTime,Standing")] RouteNode routeNode)
        {
            if (ModelState.IsValid)
            {
                routeNode.Id = Guid.NewGuid();
                _context.Add(routeNode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(routeNode);
        }

        // GET: RouteNodes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routeNode = await _context.RouteNodes.SingleOrDefaultAsync(m => m.Id == id);
            if (routeNode == null)
            {
                return NotFound();
            }
            return View(routeNode);
        }

        // POST: RouteNodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,RouteId,Name,OfficialCode,DestinationStationCode,OriginStationCode,DestinationStationName,OriginStationName,Km,DepartureTime,ArrivalTime,Standing")] RouteNode routeNode)
        {
            if (id != routeNode.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(routeNode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RouteNodeExists(routeNode.Id))
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
            return View(routeNode);
        }

        // GET: RouteNodes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routeNode = await _context.RouteNodes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (routeNode == null)
            {
                return NotFound();
            }

            return View(routeNode);
        }

        // POST: RouteNodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var routeNode = await _context.RouteNodes.SingleOrDefaultAsync(m => m.Id == id);
            _context.RouteNodes.Remove(routeNode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RouteNodeExists(Guid id)
        {
            return _context.RouteNodes.Any(e => e.Id == id);
        }
    }
}
