using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlyHighStreamlineCapstone.Data;
using FlyHighStreamlineCapstone.ViewModel;

using FlyHighStreamlineCapstone.Models;

namespace FlyHighStreamlineCapstone.Controllers
{
    public class AircraftController : Controller
    {
        private readonly FlyHighStreamlineCapstoneContext _context;

        public AircraftController(FlyHighStreamlineCapstoneContext context)
        {
            _context = context;
        }

        // GET: Aircraft
        public async Task<IActionResult> Index()
        {
            var flyHighStreamlineCapstoneContext = _context.Aircraft.Include(a => a.Airline);
            return View(await flyHighStreamlineCapstoneContext.ToListAsync());
        }

        // GET: Aircraft/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aircraft = await _context.Aircraft
                .Include(a => a.Airline)
                .FirstOrDefaultAsync(m => m.AircraftID == id);
            if (aircraft == null)
            {
                return NotFound();
            }

            return View(aircraft);
        }

        // GET: Aircraft/Create
        public IActionResult Create()
        {
            

            ViewData["AirlineID"] = new SelectList(_context.Airline, "AirlineID", "AirlineID");
            return View();
        }

        // POST: Aircraft/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AircraftID,AircraftType,RegistrationNumber,Capacity,ManufactureDate,AirlineID")] AircraftViewModel aircraftViewModel)
        {
            if (ModelState.IsValid)
            {
                Aircraft aircraft = new Aircraft {
                    AircraftID = aircraftViewModel.AircraftID,
                    AircraftType = aircraftViewModel.AircraftType,
                    RegistrationNumber = aircraftViewModel.RegistrationNumber,
                    Capacity = aircraftViewModel.Capacity,
                    ManufactureDate = aircraftViewModel.ManufactureDate,
                    AirlineID = aircraftViewModel.AirlineID,

                    
                };               
                _context.Add(aircraft);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AirlineID"] = new SelectList(_context.Airline, "AirlineID", "AirlineID", aircraftViewModel.AirlineID);
            return View(aircraftViewModel);
        }

        // GET: Aircraft/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aircraft = await _context.Aircraft.FindAsync(id);
            if (aircraft == null)
            {
                return NotFound();
            }
            ViewData["AirlineID"] = new SelectList(_context.Airline, "AirlineID", "AirlineID", aircraft.AirlineID);
            return View(aircraft);
        }

        // POST: Aircraft/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AircraftID,AircraftType,RegistrationNumber,Capacity,ManufactureDate,AirlineID")] Aircraft aircraft)
        {
            if (id != aircraft.AircraftID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aircraft);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AircraftExists(aircraft.AircraftID))
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
            ViewData["AirlineID"] = new SelectList(_context.Airline, "AirlineID", "AirlineID", aircraft.AirlineID);
            return View(aircraft);
        }

        // GET: Aircraft/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aircraft = await _context.Aircraft
                .Include(a => a.Airline)
                .FirstOrDefaultAsync(m => m.AircraftID == id);
            if (aircraft == null)
            {
                return NotFound();
            }

            return View(aircraft);
        }

        // POST: Aircraft/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aircraft = await _context.Aircraft.FindAsync(id);
            if (aircraft != null)
            {
                _context.Aircraft.Remove(aircraft);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AircraftExists(int id)
        {
            return _context.Aircraft.Any(e => e.AircraftID == id);
        }
    }
}
