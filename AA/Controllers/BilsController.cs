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
    public class BilsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BilsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bils
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {

            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CurrentFilter"] = searchString;

            IQueryable<Bil> bils = from b in _context.Bil
                                   .Include(b => b.Kategori)
                                   .Include(b => b.Marke)
                                   select b;


            if (!String.IsNullOrEmpty(searchString))
            {
                bils = bils.Where(b => b.Model.Contains(searchString)
                                       || b.Marke.Name.Contains(searchString));
            }


            if (sortOrder == "Argang")
            {
                ViewData["ArgangSortParm"] = "Argang_Desc";
            }
            else
            {
                ViewData["ArgangSortParm"] = "Argang";
            }

            switch (sortOrder)
            {
                case "name_desc":
                    bils = bils.OrderByDescending(b => b.Model);
                    break;
                case "Argang_Desc":
                    bils = bils.OrderByDescending(b => b.Argang);
                    break;
                case "Argang":
                    bils = bils.OrderBy(b => b.Argang);
                    break;
                default:
                    bils = bils.OrderBy(b => b.Marke);
                    break;
            }

            return View(await bils.AsNoTracking().ToListAsync());

        }

        // GET: Bils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bil = await _context.Bil

                .Include(b => b.Kategori)
                .Include(b => b.Marke)
                .AsNoTracking()


                .FirstOrDefaultAsync(m => m.ID == id);
            if (bil == null)
            {
                return NotFound();
            }

            return View(bil);

            
            


        }

        // GET: Bils/Create
        public IActionResult Create()
        {
            ViewData["KategoriID"] = new SelectList(_context.Kategori, "ID", "Name");
            ViewData["MarkeID"] = new SelectList(_context.Marke, "ID", "Name");
            return View();
        }

        // POST: Bils/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Model,Argang,MarkeID,KategoriID")] Bil bil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriID"] = new SelectList(_context.Kategori, "ID", "Name", bil.KategoriID);
            ViewData["MarkeID"] = new SelectList(_context.Marke, "ID", "Name", bil.MarkeID);

            return View(bil);

            
        }

        // GET: Bils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bil = await _context.Bil.FindAsync(id);
            if (bil == null)
            {
                return NotFound();
            }
            ViewData["KategoriID"] = new SelectList(_context.Kategori, "ID", "Name", bil.KategoriID);
            ViewData["MarkeID"] = new SelectList(_context.Marke, "ID", "Name", bil.MarkeID);

            return View(bil);


        }

        // POST: Bils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Model,Argang,MarkeID,KategoriID")] Bil bil)
        {
            if (id != bil.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BilExists(bil.ID))
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
            ViewData["KategoriID"] = new SelectList(_context.Kategori, "ID", "Name", bil.KategoriID);
            ViewData["MarkeID"] = new SelectList(_context.Marke, "ID", "Name", bil.MarkeID);

            return View(bil);


        }

        // GET: Bils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bil = await _context.Bil
                .Include(b => b.Kategori)
                .Include(b => b.Marke)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bil == null)
            {
                return NotFound();
            }

            return View(bil);


        }

        // POST: Bils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bil = await _context.Bil.FindAsync(id);
            _context.Bil.Remove(bil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BilExists(int id)
        {
            return _context.Bil.Any(e => e.ID == id);
        }
    }
}
