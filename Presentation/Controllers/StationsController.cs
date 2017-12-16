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
    public class StationsController : Controller
    {
        private readonly DatabaseContext _context;

        public StationsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Stations
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["OfficialCodeSortParm"] = sortOrder == "OfficialCode" ? "OfficialCode_desc" : "OfficialCode";
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = sortOrder;
            int pageSize = 10;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var stations = from s in _context.Stations
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                stations = stations.Where(s => s.Name.StartsWith(searchString)
                                       || s.OfficialCode.ToString().StartsWith(searchString)
                                       || s.Name.Contains(searchString)
                                       || s.OfficialCode.ToString().Contains(searchString)).OrderBy(
                                          s => s.Name.StartsWith(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    stations = stations.OrderByDescending(s => s.Name);
                    break;
                case "OfficialCode":
                    stations = stations.OrderBy(s => s.OfficialCode);
                    break;
                case "OfficialCode_desc":
                    stations = stations.OrderByDescending(s => s.OfficialCode);
                    break;
                default:
                    stations = stations.OrderBy(s => s.Name);
                    break;
            }

            return View(await PaginatedList<Station>.CreateAsync(stations.AsNoTracking(), page ?? 1, pageSize));
        }

        // GET: Stations/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var station = await _context.Stations
                .SingleOrDefaultAsync(m => m.Id == id);
            if (station == null)
            {
                return NotFound();
            }

            return View(station);
        }

        // GET: Stations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,OfficialCode")] Station station)
        {
            if (ModelState.IsValid)
            {
                station.Id = Guid.NewGuid();
                _context.Add(station);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(station);
        }

        // GET: Stations/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var station = await _context.Stations.SingleOrDefaultAsync(m => m.Id == id);
            if (station == null)
            {
                return NotFound();
            }
            return View(station);
        }

        // POST: Stations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,OfficialCode")] Station station)
        {
            if (id != station.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(station);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StationExists(station.Id))
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
            return View(station);
        }

        // GET: Stations/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var station = await _context.Stations
                .SingleOrDefaultAsync(m => m.Id == id);
            if (station == null)
            {
                return NotFound();
            }

            return View(station);
        }

        // POST: Stations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var station = await _context.Stations.SingleOrDefaultAsync(m => m.Id == id);
            _context.Stations.Remove(station);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StationExists(Guid id)
        {
            return _context.Stations.Any(e => e.Id == id);
        }
    }
}
