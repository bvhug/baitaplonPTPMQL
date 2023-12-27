using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC;
using Nhom2.Migrations;
using Nhom2.Models;
using NuGet.Protocol;
using Nhom2.Models.Process;

namespace Nhom2.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly ApplicationDbContext _context;
        private object _excelPro;
        private ExcelProcess _excelProcess = new ExcelProcess();

        public KhachHangController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Upload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file!=null)
                {
                    string fileExtension = Path.GetExtension(file.FileName);
                    if (fileExtension != ".xls" && fileExtension != ".xlsx")
                    {
                        ModelState.AddModelError("", "Please choose excel file to upload!");
                    }
                else
                {
                        var fileName = DateTime.Now.ToShortTimeString() + fileExtension;
                        var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", "File" + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Millisecond + fileExtension);
                        var fileLocation = new FileInfo(filePath).ToString();
                        if (file.Length > 0)
                        {
                             using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                //save file to server
                                await file.CopyToAsync(stream);
                                //read data from file and write to database
                               var dt = _excelProcess.ExcelToDataTable(fileLocation);
                                for(int i = 0; i < dt.Rows.Count; i++)
                                {
                                    //create new KhachHang obj
                                    var ps = new KhachHang();
                                    //set value to attributes 
                                    ps.MaKhachHang = dt.Rows[i][0].ToString();
                                    ps.TenKhachHang = dt.Rows[i][1].ToString();
                                    ps.Ngaysinh = dt.Rows[i][2].ToString();
                                    ps.GioiTinh = dt.Rows[i][3].ToString();
                                    ps.Diachi = dt.Rows[i][4].ToString();
                                    ps.CMND = dt.Rows[i][5].ToString();
                                    
                                }
                                await _context.SaveChangesAsync();
                                return RedirectToAction(nameof(Index));
                            }
                        }
                }
            }
            return View();
        }
        // GET: KhachHang
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.KhachHangModel.Include(k => k.GioiTinh);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: KhachHang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.KhachHangModel == null)
            {
                return NotFound();
            }

            var khachHangModel = await _context.KhachHangModel
                .Include(k => k.GioiTinh)
                .FirstOrDefaultAsync(m => m.MaKhachHang == id);
            if (khachHangModel == null)
            {
                return NotFound();
            }

            return View(khachHangModel);
        }

        // GET: KhachHang/Create
        public IActionResult Create()
        {
            ViewData["TenGioiTinh"] = new SelectList(_context.GioiTinhModel, "ID", "ID");
            return View();
        }

        // POST: KhachHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaKhachHang,TenKhachHang,Ngaysinh,TenGioiTinh,Diachi,CMND,SoDienThoai")] KhachHangModel khachHangModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khachHangModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TenGioiTinh"] = new SelectList(_context.GioiTinhModel, "ID", "ID", khachHangModel.TenGioiTinh);
            return View(khachHangModel);
        }

        // GET: KhachHang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.KhachHangModel == null)
            {
                return NotFound();
            }

            var khachHangModel = await _context.KhachHangModel.FindAsync(id);
            if (khachHangModel == null)
            {
                return NotFound();
            }
            ViewData["TenGioiTinh"] = new SelectList(_context.GioiTinhModel, "ID", "ID", khachHangModel.TenGioiTinh);
            return View(khachHangModel);
        }

        // POST: KhachHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaKhachHang,TenKhachHang,Ngaysinh,TenGioiTinh,Diachi,CMND,SoDienThoai")] KhachHangModel khachHangModel)
        {
            if (id != khachHangModel.MaKhachHang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khachHangModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhachHangModelExists(khachHangModel.MaKhachHang))
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
            ViewData["TenGioiTinh"] = new SelectList(_context.GioiTinhModel, "ID", "ID", khachHangModel.TenGioiTinh);
            return View(khachHangModel);
        }

        // GET: KhachHang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.KhachHangModel == null)
            {
                return NotFound();
            }

            var khachHangModel = await _context.KhachHangModel
                .Include(k => k.GioiTinh)
                .FirstOrDefaultAsync(m => m.MaKhachHang == id);
            if (khachHangModel == null)
            {
                return NotFound();
            }

            return View(khachHangModel);
        }

        // POST: KhachHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.KhachHangModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.KhachHangModel'  is null.");
            }
            var khachHangModel = await _context.KhachHangModel.FindAsync(id);
            if (khachHangModel != null)
            {
                _context.KhachHangModel.Remove(khachHangModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhachHangModelExists(string id)
        {
          return (_context.KhachHangModel?.Any(e => e.MaKhachHang == id)).GetValueOrDefault();
        }
    }
}
