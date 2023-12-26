using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC;
using Nhom2.Models;

namespace Nhom2.Controllers
{
    public class BangGiaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BangGiaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BangGia
        public async Task<IActionResult> Index()
        {
              return _context.BangGiaModel != null ? 
                          View(await _context.BangGiaModel.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.BangGiaModel'  is null.");
        }

        // GET: BangGia/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.BangGiaModel == null)
            {
                return NotFound();
            }

            var bangGiaModel = await _context.BangGiaModel
                .FirstOrDefaultAsync(m => m.GiaID == id);
            if (bangGiaModel == null)
            {
                return NotFound();
            }

            return View(bangGiaModel);
        }

        // GET: BangGia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BangGia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GiaID,GiaVe")] BangGiaModel bangGiaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bangGiaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bangGiaModel);
        }

        // GET: BangGia/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.BangGiaModel == null)
            {
                return NotFound();
            }

            var bangGiaModel = await _context.BangGiaModel.FindAsync(id);
            if (bangGiaModel == null)
            {
                return NotFound();
            }
            return View(bangGiaModel);
        }

        // POST: BangGia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("GiaID,GiaVe")] BangGiaModel bangGiaModel)
        {
            if (id != bangGiaModel.GiaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bangGiaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BangGiaModelExists(bangGiaModel.GiaID))
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
            return View(bangGiaModel);
        }

        // GET: BangGia/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.BangGiaModel == null)
            {
                return NotFound();
            }

            var bangGiaModel = await _context.BangGiaModel
                .FirstOrDefaultAsync(m => m.GiaID == id);
            if (bangGiaModel == null)
            {
                return NotFound();
            }

            return View(bangGiaModel);
        }

        // POST: BangGia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.BangGiaModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BangGiaModel'  is null.");
            }
            var bangGiaModel = await _context.BangGiaModel.FindAsync(id);
            if (bangGiaModel != null)
            {
                _context.BangGiaModel.Remove(bangGiaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BangGiaModelExists(string id)
        {
          return (_context.BangGiaModel?.Any(e => e.GiaID == id)).GetValueOrDefault();
        }
    }
}
