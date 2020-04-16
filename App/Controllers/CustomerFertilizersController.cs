using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Data;
using App.Models;

namespace App.Controllers
{
    public class CustomerFertilizersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerFertilizersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CustomerFertilizers
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerFertilizers.ToListAsync());
        }

        // GET: CustomerFertilizers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerFertilizer = await _context.CustomerFertilizers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerFertilizer == null)
            {
                return NotFound();
            }

            return View(customerFertilizer);
        }

        // GET: CustomerFertilizers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerFertilizers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,FertilizerId,Amount")] CustomerFertilizer customerFertilizer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerFertilizer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerFertilizer);
        }

        // GET: CustomerFertilizers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerFertilizer = await _context.CustomerFertilizers.FindAsync(id);
            if (customerFertilizer == null)
            {
                return NotFound();
            }
            return View(customerFertilizer);
        }

        // POST: CustomerFertilizers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,FertilizerId,Amount")] CustomerFertilizer customerFertilizer)
        {
            if (id != customerFertilizer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerFertilizer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerFertilizerExists(customerFertilizer.Id))
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
            return View(customerFertilizer);
        }

        // GET: CustomerFertilizers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerFertilizer = await _context.CustomerFertilizers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerFertilizer == null)
            {
                return NotFound();
            }

            return View(customerFertilizer);
        }

        // POST: CustomerFertilizers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerFertilizer = await _context.CustomerFertilizers.FindAsync(id);
            _context.CustomerFertilizers.Remove(customerFertilizer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerFertilizerExists(int id)
        {
            return _context.CustomerFertilizers.Any(e => e.Id == id);
        }
    }
}
