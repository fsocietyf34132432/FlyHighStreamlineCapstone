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
using FlyHighStreamlineCapstone.Interface;

namespace FlyHighStreamlineCapstone.Controllers
{
    public class AirlinesController : Controller
    {
        public readonly IBaseRepository<Airline> _airlinesRepository;

        public AirlinesController(IBaseRepository<Airline> airlinesRepository)
        {
            _airlinesRepository = airlinesRepository;
        }

        // GET: Airlines
        public async Task<IActionResult> Index()
        {
            return View(await _airlinesRepository.GetAllAsync());
        }

        // GET: Airlines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airline = await _airlinesRepository.GetByIdAsync(id.Value);
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
        public async Task<IActionResult> Create([Bind("AirlineID,Name,IATA_Code,ICAO_Code,Country")] AirlineViewModel airlineViewModel)
        {
            if (ModelState.IsValid)
            {
                Airline airline = new Airline {
                    AirlineID = airlineViewModel.AirlineID,
                    Name = airlineViewModel.Name,
                    IATA_Code = airlineViewModel.IATA_Code,
                    ICAO_Code = airlineViewModel.ICAO_Code,
                    Country = airlineViewModel.Country,

                };

                await _airlinesRepository.AddAsync(airline);
                await _airlinesRepository.SaveAsync();
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

            var airline = await _airlinesRepository.GetByIdAsync(id.Value);
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
        public async Task<IActionResult> Edit(int id, [Bind("AirlineID,Name,IATA_Code,ICAO_Code,Country")] Airline airline)
        {
            if (id != airline.AirlineID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _airlinesRepository.UpdateAsync(airline, );
                    await _airlinesRepository.SaveAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw;
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

            _airlinesRepository.DeleteAsync(id.Value);

            return View();
        }

        // POST: Airlines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var airline = await _airlinesRepository.GetByIdAsync(id);
            if (airline != null)
            {
                _airlinesRepository.DeleteAsync(airline.AirlineID);
            }

            await _airlinesRepository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private Task<Airline> AirlineExists(int id)
        {
            var airline = _airlinesRepository.GetByIdAsync(id);

            return airline;
        }
    }
}
