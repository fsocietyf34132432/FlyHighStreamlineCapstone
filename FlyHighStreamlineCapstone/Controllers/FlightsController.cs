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
    public class FlightsController : Controller
    {
        private readonly FlyHighStreamlineCapstoneContext _context;

        public FlightsController(FlyHighStreamlineCapstoneContext context)
        {
            _context = context;
        }

        // GET: Flights
        public async Task<IActionResult> Index()
        {
            var flightlistViewModel = _context.Flight.ToList();

            List<FlightListViewModel> list = new List<FlightListViewModel>();
            foreach (var flight in flightlistViewModel)
            {
                // Create a new FlightListViewModel instance for EACH flight
                FlightListViewModel flightmodel = new FlightListViewModel
                {
                    FlightId = flight.FlightId,
                    FlightNo = flight.FlightNo,
                    DepartureTime = flight.DepartureTime,
                    ArrivalTime = flight.ArrivalTime,
                    Status = flight.Status,
                    Duration = flight.Duration,
                    DepartureAirportId = flight.DepartureAirportId,
                    ArrivalAirportId = flight.ArrivalAirportId,
                    AirlineName = _context.Airline.Where(x => x.AirlineId == flight.AirlineId).FirstOrDefault()?.Name ?? default!
                };

                list.Add(flightmodel);
            }

            return View(list);
        }

        // GET: Flights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flight
                .FirstOrDefaultAsync(m => m.FlightId == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // GET: Flights/Create
        public IActionResult Create()
        {
            ViewData["AirlineId"] = new SelectList(_context.Airline, "AirlineId", "Name"); // Use "Name" for display
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlightId,FlightNo,DepartureTime,ArrivalTime,Status,Duration,DepartureAirportId,ArrivalAirportId,AirlineId")] FlightViewModel flightViewModel)
        {
            if (ModelState.IsValid)
            {
                Flight flight = new Flight
                {
                    FlightId = flightViewModel.FlightId,
                    FlightNo = flightViewModel.FlightNo,
                    DepartureTime = flightViewModel.DepartureTime,
                    ArrivalTime = flightViewModel.ArrivalTime,
                    Status = flightViewModel.Status,
                    Duration = flightViewModel.Duration,
                    DepartureAirportId = flightViewModel.DepartureAirportId,
                    ArrivalAirportId = flightViewModel.ArrivalAirportId,
                    AirlineId = flightViewModel.AirlineId,
            

                };

                _context.Add(flight);
                await _context.SaveChangesAsync();
                // Clear ModelState to force a refresh
                ModelState.Clear();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AirlineId"] = new SelectList(_context.Airline, "AirlineId", "Name");
            return View(flightViewModel);
        }

        // GET: Flights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flight.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlightId,FlightNo,DepartureTime,ArrivalTime,Status,Duration,DepartureAirportId,ArrivalAirportId,AirlineId,AircraftId")] Flight flight)
        {
            if (id != flight.FlightId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightExists(flight.FlightId))
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
            return View(flight);
        }

        // GET: Flights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flight
                .FirstOrDefaultAsync(m => m.FlightId == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flight = await _context.Flight.FindAsync(id);
            if (flight != null)
            {
                _context.Flight.Remove(flight);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightExists(int id)
        {
            return _context.Flight.Any(e => e.FlightId == id);
        }
    }
}
