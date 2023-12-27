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
    public class TaiXeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaiXeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TaiXe
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TaiXeModel.Include(t => t.GioiTinh);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TaiXe/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TaiXeModel == null)
            {
                return NotFound();
            }

            var taiXeModel = await _context.TaiXeModel
                .Include(t => t.GioiTinh)
                .FirstOrDefaultAsync(m => m.MaTaiXe == id);
            if (taiXeModel == null)
            {
                return NotFound();
            }

            return View(taiXeModel);
        }

        // GET: TaiXe/Create
        public IActionResult Create()
        {
            ViewData["TenGioiTinh"] = new SelectList(_context.GioiTinhModel, "ID", "TenGioiTinh");
            return View();
        }

        // POST: TaiXe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaTaiXe,TenTaiXe,Ngaysinh,TenGioiTinh,Diachi,CMND,SoDienThoai")] TaiXeModel taiXeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taiXeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TenGioiTinh"] = new SelectList(_context.GioiTinhModel, "ID", "ID", taiXeModel.TenGioiTinh);
            return View(taiXeModel);
        }

        // GET: TaiXe/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.TaiXeModel == null)
            {
                return NotFound();
            }

            var taiXeModel = await _context.TaiXeModel.FindAsync(id);
            if (taiXeModel == null)
            {
                return NotFound();
            }
            ViewData["TenGioiTinh"] = new SelectList(_context.GioiTinhModel, "ID", "ID", taiXeModel.TenGioiTinh);
            return View(taiXeModel);
        }

        // POST: TaiXe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaTaiXe,TenTaiXe,Ngaysinh,TenGioiTinh,Diachi,CMND,SoDienThoai")] TaiXeModel taiXeModel)
        {
            if (id != taiXeModel.MaTaiXe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taiXeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaiXeModelExists(taiXeModel.MaTaiXe))
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
            ViewData["TenGioiTinh"] = new SelectList(_context.GioiTinhModel, "ID", "ID", taiXeModel.TenGioiTinh);
            return View(taiXeModel);
        }

        // GET: TaiXe/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.TaiXeModel == null)
            {
                return NotFound();
            }

            var taiXeModel = await _context.TaiXeModel
                .Include(t => t.GioiTinh)
                .FirstOrDefaultAsync(m => m.MaTaiXe == id);
            if (taiXeModel == null)
            {
                return NotFound();
            }

            return View(taiXeModel);
        }

        // POST: TaiXe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.TaiXeModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TaiXeModel'  is null.");
            }
            var taiXeModel = await _context.TaiXeModel.FindAsync(id);
            if (taiXeModel != null)
            {
                _context.TaiXeModel.Remove(taiXeModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaiXeModelExists(string id)
        {
          return (_context.TaiXeModel?.Any(e => e.MaTaiXe == id)).GetValueOrDefault();
        }
    }
}
