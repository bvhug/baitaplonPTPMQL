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
    public class VeXeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VeXeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VeXe
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.VeXeModel.Include(v => v.KhachHang).Include(v => v.NhanVien).Include(v => v.TenXe);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: VeXe/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.VeXeModel == null)
            {
                return NotFound();
            }

            var veXeModel = await _context.VeXeModel
                .Include(v => v.KhachHang)
                .Include(v => v.NhanVien)
                .Include(v => v.TenXe)
                .FirstOrDefaultAsync(m => m.MaVe == id);
            if (veXeModel == null)
            {
                return NotFound();
            }

            return View(veXeModel);
        }

        // GET: VeXe/Create
        public IActionResult Create()
        {
            ViewData["MaKhachHang"] = new SelectList(_context.Set<KhachHangModel>(), "MaKhachHang", "MaKhachHang");
            ViewData["MaNhanVien"] = new SelectList(_context.Set<NhanVienModel>(), "MaNhanVien", "MaNhanVien");
            ViewData["TenXe_BienSo"] = new SelectList(_context.Set<TenXeModel>(), "XeID", "XeID");
            return View();
        }

        // POST: VeXe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaVe,TenVe,TenXe_BienSo,MaNhanVien,MaKhachHang")] VeXeModel veXeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(veXeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKhachHang"] = new SelectList(_context.Set<KhachHangModel>(), "MaKhachHang", "MaKhachHang", veXeModel.MaKhachHang);
            ViewData["MaNhanVien"] = new SelectList(_context.Set<NhanVienModel>(), "MaNhanVien", "MaNhanVien", veXeModel.MaNhanVien);
            ViewData["TenXe_BienSo"] = new SelectList(_context.Set<TenXeModel>(), "XeID", "XeID", veXeModel.TenXe_BienSo);
            return View(veXeModel);
        }

        // GET: VeXe/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.VeXeModel == null)
            {
                return NotFound();
            }

            var veXeModel = await _context.VeXeModel.FindAsync(id);
            if (veXeModel == null)
            {
                return NotFound();
            }
            ViewData["MaKhachHang"] = new SelectList(_context.Set<KhachHangModel>(), "MaKhachHang", "MaKhachHang", veXeModel.MaKhachHang);
            ViewData["MaNhanVien"] = new SelectList(_context.Set<NhanVienModel>(), "MaNhanVien", "MaNhanVien", veXeModel.MaNhanVien);
            ViewData["TenXe_BienSo"] = new SelectList(_context.Set<TenXeModel>(), "XeID", "XeID", veXeModel.TenXe_BienSo);
            return View(veXeModel);
        }

        // POST: VeXe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaVe,TenVe,TenXe_BienSo,MaNhanVien,MaKhachHang")] VeXeModel veXeModel)
        {
            if (id != veXeModel.MaVe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veXeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeXeModelExists(veXeModel.MaVe))
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
            ViewData["MaKhachHang"] = new SelectList(_context.Set<KhachHangModel>(), "MaKhachHang", "MaKhachHang", veXeModel.MaKhachHang);
            ViewData["MaNhanVien"] = new SelectList(_context.Set<NhanVienModel>(), "MaNhanVien", "MaNhanVien", veXeModel.MaNhanVien);
            ViewData["TenXe_BienSo"] = new SelectList(_context.Set<TenXeModel>(), "XeID", "XeID", veXeModel.TenXe_BienSo);
            return View(veXeModel);
        }

        // GET: VeXe/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.VeXeModel == null)
            {
                return NotFound();
            }

            var veXeModel = await _context.VeXeModel
                .Include(v => v.KhachHang)
                .Include(v => v.NhanVien)
                .Include(v => v.TenXe)
                .FirstOrDefaultAsync(m => m.MaVe == id);
            if (veXeModel == null)
            {
                return NotFound();
            }

            return View(veXeModel);
        }

        // POST: VeXe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.VeXeModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.VeXeModel'  is null.");
            }
            var veXeModel = await _context.VeXeModel.FindAsync(id);
            if (veXeModel != null)
            {
                _context.VeXeModel.Remove(veXeModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeXeModelExists(string id)
        {
          return (_context.VeXeModel?.Any(e => e.MaVe == id)).GetValueOrDefault();
        }
    }
}
