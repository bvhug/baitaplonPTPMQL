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
    public class XeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public XeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Xe
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.XeModel.Include(x => x.TaiXe).Include(x => x.TenXe);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Xe/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.XeModel == null)
            {
                return NotFound();
            }

            var xeModel = await _context.XeModel
                .Include(x => x.TaiXe)
                .Include(x => x.TenXe)
                .FirstOrDefaultAsync(m => m.MaXe == id);
            if (xeModel == null)
            {
                return NotFound();
            }

            return View(xeModel);
        }

        // GET: Xe/Create
        public IActionResult Create()
        {
            ViewData["MaTaiXe"] = new SelectList(_context.Set<TaiXeModel>(), "MaTaiXe", "MaTaiXe");
            ViewData["TenCuaXe"] = new SelectList(_context.Set<TenXeModel>(), "XeID", "XeID");
            return View();
        }

        // POST: Xe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaXe,TenCuaXe,MaTaiXe")] XeModel xeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(xeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaTaiXe"] = new SelectList(_context.Set<TaiXeModel>(), "MaTaiXe", "MaTaiXe", xeModel.MaTaiXe);
            ViewData["TenCuaXe"] = new SelectList(_context.Set<TenXeModel>(), "XeID", "XeID", xeModel.TenCuaXe);
            return View(xeModel);
        }

        // GET: Xe/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.XeModel == null)
            {
                return NotFound();
            }

            var xeModel = await _context.XeModel.FindAsync(id);
            if (xeModel == null)
            {
                return NotFound();
            }
            ViewData["MaTaiXe"] = new SelectList(_context.Set<TaiXeModel>(), "MaTaiXe", "MaTaiXe", xeModel.MaTaiXe);
            ViewData["TenCuaXe"] = new SelectList(_context.Set<TenXeModel>(), "XeID", "XeID", xeModel.TenCuaXe);
            return View(xeModel);
        }

        // POST: Xe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaXe,TenCuaXe,MaTaiXe")] XeModel xeModel)
        {
            if (id != xeModel.MaXe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(xeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!XeModelExists(xeModel.MaXe))
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
            ViewData["MaTaiXe"] = new SelectList(_context.Set<TaiXeModel>(), "MaTaiXe", "MaTaiXe", xeModel.MaTaiXe);
            ViewData["TenCuaXe"] = new SelectList(_context.Set<TenXeModel>(), "XeID", "XeID", xeModel.TenCuaXe);
            return View(xeModel);
        }

        // GET: Xe/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.XeModel == null)
            {
                return NotFound();
            }

            var xeModel = await _context.XeModel
                .Include(x => x.TaiXe)
                .Include(x => x.TenXe)
                .FirstOrDefaultAsync(m => m.MaXe == id);
            if (xeModel == null)
            {
                return NotFound();
            }

            return View(xeModel);
        }

        // POST: Xe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.XeModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.XeModel'  is null.");
            }
            var xeModel = await _context.XeModel.FindAsync(id);
            if (xeModel != null)
            {
                _context.XeModel.Remove(xeModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool XeModelExists(string id)
        {
          return (_context.XeModel?.Any(e => e.MaXe == id)).GetValueOrDefault();
        }
    }
}
