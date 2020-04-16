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
    public class LandsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LandsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lands
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lands.ToListAsync());
        }

        // GET: Lands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var land = await _context.Lands
                .FirstOrDefaultAsync(m => m.Id == id);
            if (land == null)
            {
                return NotFound();
            }

            return View(land);
        }

        // GET: Lands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,LandTypeId,Area,CreatedAt")] Land land)
        {
            if (ModelState.IsValid)
            {
                _context.Add(land);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(land);
        }

        // GET: Lands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var land = await _context.Lands.FindAsync(id);
            if (land == null)
            {
                return NotFound();
            }
            return View(land);
        }

        // POST: Lands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,LandTypeId,Area,CreatedAt")] Land land)
        {
            if (id != land.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(land);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LandExists(land.Id))
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
            return View(land);
        }

        // GET: Lands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var land = await _context.Lands
                .FirstOrDefaultAsync(m => m.Id == id);
            if (land == null)
            {
                return NotFound();
            }

            return View(land);
        }

        // POST: Lands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var land = await _context.Lands.FindAsync(id);
            _context.Lands.Remove(land);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LandExists(int id)
        {
            return _context.Lands.Any(e => e.Id == id);
        }
    }
}
