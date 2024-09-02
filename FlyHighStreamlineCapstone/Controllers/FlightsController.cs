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
            var flightList = await _context.Flight
                .Include(f => f.DepartureAirport)
                .Include(f => f.ArrivalAirport)
                .Include(f => f.Airline)
                .Include(f => f.Aircraft)
                .ToListAsync();

            var flightListViewModel = flightList.Select(flight => new FlightListViewModel
            {
                FlightId = flight.FlightId,
                FlightNo = flight.FlightNo,
                DepartureTime = flight.DepartureTime,
                ArrivalTime = flight.ArrivalTime,
                Status = flight.Status,
                Duration = flight.Duration,
                DepartureAirportName = flight.DepartureAirport?.AirportName ?? default!,
                ArrivalAirportName = flight.ArrivalAirport?.AirportName ?? default!,
                AirlineName = flight.Airline?.Name ?? default!,
                AircraftRegistrationNumber = flight.Aircraft?.RegistrationNumber ?? default!
            }).ToList();

            return View(flightListViewModel);
        }


        // GET: Flights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flight
                .Include(f => f.Aircraft)
                .Include(f => f.Airline)
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
            ViewBag.DepartureAirportId = new SelectList(_context.Airport, "AirportId", "AirportName");
            ViewBag.ArrivalAirportId = new SelectList(_context.Airport, "AirportId", "AirportName");
            ViewBag.AirlineId = new SelectList(_context.Airline, "AirlineId", "Name");
            ViewBag.AircraftId = new SelectList(_context.Aircraft, "AircraftId", "RegistrationNumber");
            return View();
        }


        // POST: Flights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlightId,FlightNo,DepartureTime,ArrivalTime,Status,Duration,DepartureAirportId,ArrivalAirportId,AirlineId,AircraftId,AirportId")] FlightViewModel flightViewModel)
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
                    AircraftId = flightViewModel.AircraftId,
             


                };
                _context.Add(flight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AirportId"] = new SelectList(_context.Aircraft, "AirportId", "AirportName");
            ViewData["AircraftId"] = new SelectList(_context.Aircraft, "AircraftId", "RegistrationNumber");
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
            ViewData["AircraftId"] = new SelectList(_context.Aircraft, "AircraftId", "AircraftId", flight.AircraftId);
            ViewData["AirlineId"] = new SelectList(_context.Airline, "AirlineId", "AirlineId", flight.AirlineId);
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
            ViewData["AircraftId"] = new SelectList(_context.Aircraft, "AircraftId", "AircraftId", flight.AircraftId);
            ViewData["AirlineId"] = new SelectList(_context.Airline, "AirlineId", "AirlineId", flight.AirlineId);
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
                .Include(f => f.Aircraft)
                .Include(f => f.Airline)
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
