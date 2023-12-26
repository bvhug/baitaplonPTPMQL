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
    public class GioiTinhController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GioiTinhController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GioiTinh
        public async Task<IActionResult> Index()
        {
              return _context.GioiTinhModel != null ? 
                          View(await _context.GioiTinhModel.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.GioiTinhModel'  is null.");
        }

        // GET: GioiTinh/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.GioiTinhModel == null)
            {
                return NotFound();
            }

            var gioiTinhModel = await _context.GioiTinhModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gioiTinhModel == null)
            {
                return NotFound();
            }

            return View(gioiTinhModel);
        }

        // GET: GioiTinh/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GioiTinh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TenGioiTinh")] GioiTinhModel gioiTinhModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gioiTinhModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gioiTinhModel);
        }

        // GET: GioiTinh/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.GioiTinhModel == null)
            {
                return NotFound();
            }

            var gioiTinhModel = await _context.GioiTinhModel.FindAsync(id);
            if (gioiTinhModel == null)
            {
                return NotFound();
            }
            return View(gioiTinhModel);
        }

        // POST: GioiTinh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,TenGioiTinh")] GioiTinhModel gioiTinhModel)
        {
            if (id != gioiTinhModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gioiTinhModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GioiTinhModelExists(gioiTinhModel.ID))
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
            return View(gioiTinhModel);
        }

        // GET: GioiTinh/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.GioiTinhModel == null)
            {
                return NotFound();
            }

            var gioiTinhModel = await _context.GioiTinhModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gioiTinhModel == null)
            {
                return NotFound();
            }

            return View(gioiTinhModel);
        }

        // POST: GioiTinh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.GioiTinhModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.GioiTinhModel'  is null.");
            }
            var gioiTinhModel = await _context.GioiTinhModel.FindAsync(id);
            if (gioiTinhModel != null)
            {
                _context.GioiTinhModel.Remove(gioiTinhModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GioiTinhModelExists(string id)
        {
          return (_context.GioiTinhModel?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
