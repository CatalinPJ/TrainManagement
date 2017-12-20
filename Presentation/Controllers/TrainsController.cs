using System;
using System.Linq;
using System.Threading.Tasks;
using Bussiness;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Domain.Entities;
using Data.Domain.Interfaces;
using Data.Persistance;

namespace Presentation.Controllers
{
    public class TrainsController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IRepository<Train> _repository;

        public TrainsController(DatabaseContext context, IRepository<Train> repository)
        {
            _context = context;
            _repository = repository;
        }

        // GET: Trains
        public async Task<IActionResult> Index()
        {
            return View(_repository.GetAll());
        }

        // GET: Trains/Details/5
        public async Task<IActionResult> Details(string officialNumber)
        {
            if (officialNumber == null)
            {
                return NotFound();
            }

            var train = await _context.Trains
                .SingleOrDefaultAsync(m => m.OfficialNumber == officialNumber);
            if (train == null)
            {
                return NotFound();
            }
            return View(train);
        }

        // GET: Trains/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Category,CumulatedKm,OfficialNumber,Length,OperatorCode,OwnerCode,Rank,Weight")] Train train)
        {
            if (ModelState.IsValid)
            {
                train.Id = Guid.NewGuid();
                _context.Add(train);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(train);
        }

        // GET: Trains/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var train = await _context.Trains.SingleOrDefaultAsync(m => m.Id == id);
            if (train == null)
            {
                return NotFound();
            }
            return View(train);
        }

        // POST: Trains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Category,CumulatedKm,OfficialNumber,Length,OperatorCode,OwnerCode,Rank,Weight")] Train train)
        {
            if (id != train.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(train);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainExists(train.Id))
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
            return View(train);
        }

        // GET: Trains/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var train = await _context.Trains
                .SingleOrDefaultAsync(m => m.Id == id);
            if (train == null)
            {
                return NotFound();
            }

            return View(train);
        }

        // POST: Trains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var train = await _context.Trains.SingleOrDefaultAsync(m => m.Id == id);
            _context.Trains.Remove(train);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainExists(Guid id)
        {
            return _context.Trains.Any(e => e.Id == id);
        }
    }
}
