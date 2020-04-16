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
    public class LandTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LandTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LandTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LandTypes.ToListAsync());
        }

        // GET: LandTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landType = await _context.LandTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (landType == null)
            {
                return NotFound();
            }

            return View(landType);
        }

        // GET: LandTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LandTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] LandType landType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(landType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(landType);
        }

        // GET: LandTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landType = await _context.LandTypes.FindAsync(id);
            if (landType == null)
            {
                return NotFound();
            }
            return View(landType);
        }

        // POST: LandTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] LandType landType)
        {
            if (id != landType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(landType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LandTypeExists(landType.Id))
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
            return View(landType);
        }

        // GET: LandTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landType = await _context.LandTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (landType == null)
            {
                return NotFound();
            }

            return View(landType);
        }

        // POST: LandTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var landType = await _context.LandTypes.FindAsync(id);
            _context.LandTypes.Remove(landType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LandTypeExists(int id)
        {
            return _context.LandTypes.Any(e => e.Id == id);
        }
    }
}
