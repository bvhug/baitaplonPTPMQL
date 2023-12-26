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
    public class NhanVienController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NhanVienController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NhanVien
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.NhanVienModel.Include(n => n.GioiTinh);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: NhanVien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.NhanVienModel == null)
            {
                return NotFound();
            }

            var nhanVienModel = await _context.NhanVienModel
                .Include(n => n.GioiTinh)
                .FirstOrDefaultAsync(m => m.MaNhanVien == id);
            if (nhanVienModel == null)
            {
                return NotFound();
            }

            return View(nhanVienModel);
        }

        // GET: NhanVien/Create
        public IActionResult Create()
        {
            ViewData["TenGioiTinh"] = new SelectList(_context.GioiTinhModel, "ID", "ID");
            return View();
        }

        // POST: NhanVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNhanVien,TenNhanVien,Ngaysinh,TenGioiTinh,Diachi,CMND,SoDienThoai")] NhanVienModel nhanVienModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanVienModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TenGioiTinh"] = new SelectList(_context.GioiTinhModel, "ID", "ID", nhanVienModel.TenGioiTinh);
            return View(nhanVienModel);
        }

        // GET: NhanVien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.NhanVienModel == null)
            {
                return NotFound();
            }

            var nhanVienModel = await _context.NhanVienModel.FindAsync(id);
            if (nhanVienModel == null)
            {
                return NotFound();
            }
            ViewData["TenGioiTinh"] = new SelectList(_context.GioiTinhModel, "ID", "ID", nhanVienModel.TenGioiTinh);
            return View(nhanVienModel);
        }

        // POST: NhanVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaNhanVien,TenNhanVien,Ngaysinh,TenGioiTinh,Diachi,CMND,SoDienThoai")] NhanVienModel nhanVienModel)
        {
            if (id != nhanVienModel.MaNhanVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanVienModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanVienModelExists(nhanVienModel.MaNhanVien))
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
            ViewData["TenGioiTinh"] = new SelectList(_context.GioiTinhModel, "ID", "ID", nhanVienModel.TenGioiTinh);
            return View(nhanVienModel);
        }

        // GET: NhanVien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.NhanVienModel == null)
            {
                return NotFound();
            }

            var nhanVienModel = await _context.NhanVienModel
                .Include(n => n.GioiTinh)
                .FirstOrDefaultAsync(m => m.MaNhanVien == id);
            if (nhanVienModel == null)
            {
                return NotFound();
            }

            return View(nhanVienModel);
        }

        // POST: NhanVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.NhanVienModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.NhanVienModel'  is null.");
            }
            var nhanVienModel = await _context.NhanVienModel.FindAsync(id);
            if (nhanVienModel != null)
            {
                _context.NhanVienModel.Remove(nhanVienModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienModelExists(string id)
        {
          return (_context.NhanVienModel?.Any(e => e.MaNhanVien == id)).GetValueOrDefault();
        }
    }
}
