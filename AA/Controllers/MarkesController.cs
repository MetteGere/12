using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AA.Data;
using AA.Models;

namespace AA.Controllers
{
    public class MarkesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MarkesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Markes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Marke.ToListAsync());
        }

        // GET: Markes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marke = await _context.Marke
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (marke == null)
            {
                return NotFound();
            }
            ViewData["bilermedsammemarke"] = await _context.Bil.Where(b => b.MarkeID == id).ToListAsync();


            return View(marke);
        }

      

        // GET: Markes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Markes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Country")] Marke marke)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marke);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marke);
        }

        // GET: Markes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marke = await _context.Marke.FindAsync(id);
            if (marke == null)
            {
                return NotFound();
            }
            return View(marke);
        }

        // POST: Markes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Country")] Marke marke)
        {
            if (id != marke.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marke);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarkeExists(marke.ID))
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
            return View(marke);
        }

        // GET: Markes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marke = await _context.Marke
                .FirstOrDefaultAsync(m => m.ID == id);
            if (marke == null)
            {
                return NotFound();
            }

            return View(marke);
        }

        // POST: Markes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marke = await _context.Marke.FindAsync(id);
            _context.Marke.Remove(marke);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarkeExists(int id)
        {
            return _context.Marke.Any(e => e.ID == id);
        }
    }
}
