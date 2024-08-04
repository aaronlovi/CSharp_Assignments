using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarInsurance;
using CarInsurance.Models;
using System.Runtime.ConstrainedExecution;

namespace CarInsurance.Controllers
{
    public class InsureeController : Controller
    {
        private readonly InsuranceDbContext _context;

        public InsureeController(InsuranceDbContext context)
        {
            _context = context;
        }

        // GET: Insuree
        public async Task<IActionResult> Index()
        {
            return View(await _context.Insurees.ToListAsync());
        }

        // GET: Insuree/Admin
        public async Task<IActionResult> Admin()
        {
            return View(await _context.Insurees.ToListAsync());
        }

        // GET: Insuree/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuree = await _context.Insurees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insuree == null)
            {
                return NotFound();
            }

            return View(insuree);
        }

        // GET: Insuree/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                insuree.Quote = CalculateQuote(insuree);
                _context.Add(insuree);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(insuree);
        }

        // GET: Insuree/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuree = await _context.Insurees.FindAsync(id);
            if (insuree == null)
            {
                return NotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
        {
            if (id != insuree.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insuree);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsureeExists(insuree.Id))
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
            return View(insuree);
        }

        // GET: Insuree/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuree = await _context.Insurees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insuree == null)
            {
                return NotFound();
            }

            return View(insuree);
        }

        // POST: Insuree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var insuree = await _context.Insurees.FindAsync(id);
            if (insuree != null)
            {
                _context.Insurees.Remove(insuree);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsureeExists(int id)
        {
            return _context.Insurees.Any(e => e.Id == id);
        }

        private decimal CalculateQuote(Insuree insuree)
        {
            // Start with a base of $50 / month.
            decimal quote = 50M;

            // If the user is 18 or under, add $100 to the monthly total.
            bool is18OrUnder = insuree.DateOfBirth.AddYears(19).AddDays(-1) > DateTime.Now;
            if (is18OrUnder)
                quote += 100M;

            // If the user is from 19 to 25, add $50 to the monthly total.
            bool is25OrUnder = insuree.DateOfBirth.AddYears(26).AddDays(-1) > DateTime.Now;
            if (!is18OrUnder && is25OrUnder)
                quote += 50M;

            // If the user is 26 or older, add $25 to the monthly total. Double check your code to ensure all ages are covered.
            if (!is25OrUnder)
                quote += 25M;

            // If the car's year is before 2000, add $25 to the monthly total.
            if (insuree.CarYear < 2000)
                quote += 25M;

            // If the car's year is after 2015, add $25 to the monthly total.
            if (insuree.CarYear > 2015)
                quote += 25M;

            // If the car's Make is a Porsche, add $25 to the price.
            if (insuree.CarMake.ToLower() == "porsche")
                quote += 25M;

            // If the car's Make is a Porsche and its model is a 911 Carrera, add an additional $25 to the price.
            // (Meaning, this specific car will add a total of $50 to the price.)
            if (insuree.CarMake.ToLower() == "porsche" && insuree.CarModel.ToLower() == "911 carrera")
                quote += 25M;

            // Add $10 to the monthly total for every speeding ticket the user has.
            quote += insuree.SpeedingTickets * 10M;

            // If the user has ever had a DUI, add 25% to the total.
            if (insuree.DUI)
                quote *= 1.25M;

            // If it's full coverage, add 50% to the total.
            if (insuree.CoverageType)
                quote *= 1.5M;

            return quote;
        }
    }
}
