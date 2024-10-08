﻿using System;
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
    public class AirlinesController : Controller
    {
        private readonly FlyHighStreamlineCapstoneContext _context;

        public AirlinesController(FlyHighStreamlineCapstoneContext context)
        {
            _context = context;
        }

        // GET: Airlines
        public async Task<IActionResult> Index()
        {
            return View(await _context.Airline.ToListAsync());
        }

        // GET: Airlines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airline = await _context.Airline
                .FirstOrDefaultAsync(m => m.AirlineId == id);
            if (airline == null)
            {
                return NotFound();
            }

            return View(airline);
        }

        // GET: Airlines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Airlines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AirlineId,Name,IATA_Code,ICAO_Code,Country")] AirlineViewModel airlineViewModel)
        {
            if (ModelState.IsValid)
            {
                Airline airline = new Airline {
                    AirlineId = airlineViewModel.AirlineId,
                    Name = airlineViewModel.Name,
                    IATA_Code = airlineViewModel.IATA_Code,
                    ICAO_Code = airlineViewModel.ICAO_Code,
                    Country = airlineViewModel.Country,

                };


                _context.Add(airline);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(airlineViewModel);
        }

        // GET: Airlines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airline = await _context.Airline.FindAsync(id);
            if (airline == null)
            {
                return NotFound();
            }
            return View(airline);
        }

        // POST: Airlines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AirlineId,Name,IATA_Code,ICAO_Code,Country")] Airline airline)
        {
            if (id != airline.AirlineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(airline);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AirlineExists(airline.AirlineId))
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
            return View(airline);
        }

        // GET: Airlines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airline = await _context.Airline
                .FirstOrDefaultAsync(m => m.AirlineId == id);
            if (airline == null)
            {
                return NotFound();
            }

            return View(airline);
        }

        // POST: Airlines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var airline = await _context.Airline.FindAsync(id);
            if (airline != null)
            {
                _context.Airline.Remove(airline);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AirlineExists(int id)
        {
            return _context.Airline.Any(e => e.AirlineId == id);
        }
    }
}
