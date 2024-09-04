using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlyHighStreamlineCapstone.Data;
using FlyHighStreamlineCapstone.Models;
using FlyHighStreamlineCapstone.ViewModel;

namespace FlyHighStreamlineCapstone.Controllers
{
    public class SeatsController : Controller
    {
        private readonly FlyHighStreamlineCapstoneContext _context;

        public SeatsController(FlyHighStreamlineCapstoneContext context)
        {
            _context = context;
        }

        // GET: Seats
        public async Task<IActionResult> Index()
        {
            var seatList = await _context.Seat
        .Include(s => s.Aircraft) // Include the related Flight entity
        .ToListAsync();

            var seatListViewModels = seatList.Select(seat => new SeatListViewModel
            {
                SeatId = seat.SeatId,                     // Use SeatId from the Seat object
                SeatNumber = seat.SeatNumber,
                AircraftType = seat.Aircraft.AircraftType,
                Class = seat.Class,
                IsAvailable = seat.IsAvailable,
                Price = seat.Price,
                // If you want to display flight-related information, you'll need to adjust your SeatListViewModel
                // and include properties like FlightNo, DepartureTime, etc., and populate them here using seat.Flight
            }).ToList();

            return View(seatListViewModels);
        }


        // GET: Seats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seat = await _context.Seat
                .Include(s => s.Aircraft)
                .FirstOrDefaultAsync(m => m.SeatId == id);
            if (seat == null)
            {
                return NotFound();
            }

            return View(seat);
        }

        // GET: Seats/Create
        public IActionResult Create()
        {
            ViewData["AircraftId"] = new SelectList(_context.Aircraft, "AircraftId", "AircraftType");
            return View();
        }

        // POST: Seats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SeatId,AircraftId,SeatNumber,Class,IsAvailable,Price")] SeatViewModel seatViewModel)
        {
            if (ModelState.IsValid)
            {
                Seat seat = new Seat
                {
                    SeatId = seatViewModel.SeatId,
                    AircraftId = seatViewModel.AircraftId, // Set the FlightId property
                    SeatNumber = seatViewModel.SeatNumber,
                    Class = seatViewModel.Class,
                    IsAvailable = seatViewModel.IsAvailable,
                    Price = seatViewModel.Price
                };
                _context.Add(seat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AircraftId"] = new SelectList(_context.Aircraft, "AircraftId", "AircraftId", seatViewModel.AircraftId);
            return View(seatViewModel);
        }

        // GET: Seats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seat = await _context.Seat.FindAsync(id);
            if (seat == null)
            {
                return NotFound();
            }
            ViewData["AircraftId"] = new SelectList(_context.Aircraft, "AircraftId", "AircraftId", seat.AircraftId);
            return View(seat);
        }

        // POST: Seats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SeatId,AircraftId,SeatNumber,Class,IsAvailable,Price")] Seat seat)
        {
            if (id != seat.SeatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeatExists(seat.SeatId))
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
            ViewData["AircraftId"] = new SelectList(_context.Aircraft, "AircraftId", "AircraftId", seat.AircraftId);
            return View(seat);
        }

        // GET: Seats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seat = await _context.Seat
                .Include(s => s.Aircraft)
                .FirstOrDefaultAsync(m => m.SeatId == id);
            if (seat == null)
            {
                return NotFound();
            }

            return View(seat);
        }

        // POST: Seats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seat = await _context.Seat.FindAsync(id);
            if (seat != null)
            {
                _context.Seat.Remove(seat);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeatExists(int id)
        {
            return _context.Seat.Any(e => e.SeatId == id);
        }
    }
}
