using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nhom2.Models.Process;
using MVC;
using Nhom2.Models;

namespace Nhom2.Controllers
{
    public class TenXeController : Controller
    {
        private readonly ApplicationDbContext _context;
       
        public TenXeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TenXe
        public async Task<IActionResult> Index()
        {
              return _context.TenXeModel != null ? 
                          View(await _context.TenXeModel.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TenXeModel'  is null.");
        }

        // GET: TenXe/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TenXeModel == null)
            {
                return NotFound();
            }

            var tenXeModel = await _context.TenXeModel
                .FirstOrDefaultAsync(m => m.XeID == id);
            if (tenXeModel == null)
            {
                return NotFound();
            }

            return View(tenXeModel);
        }

        // GET: TenXe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TenXe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("XeID,TenXe_BienSo")] TenXeModel tenXeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tenXeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tenXeModel);
        }

        // GET: TenXe/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.TenXeModel == null)
            {
                return NotFound();
            }

            var tenXeModel = await _context.TenXeModel.FindAsync(id);
            if (tenXeModel == null)
            {
                return NotFound();
            }
            return View(tenXeModel);
        }

        // POST: TenXe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("XeID,TenXe_BienSo")] TenXeModel tenXeModel)
        {
            if (id != tenXeModel.XeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tenXeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TenXeModelExists(tenXeModel.XeID))
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
            return View(tenXeModel);
        }

        // GET: TenXe/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.TenXeModel == null)
            {
                return NotFound();
            }

            var tenXeModel = await _context.TenXeModel
                .FirstOrDefaultAsync(m => m.XeID == id);
            if (tenXeModel == null)
            {
                return NotFound();
            }

            return View(tenXeModel);
        }

        // POST: TenXe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.TenXeModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TenXeModel'  is null.");
            }
            var tenXeModel = await _context.TenXeModel.FindAsync(id);
            if (tenXeModel != null)
            {
                _context.TenXeModel.Remove(tenXeModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TenXeModelExists(string id)
        {
          return (_context.TenXeModel?.Any(e => e.XeID == id)).GetValueOrDefault();
        }
         private ExcelProcess _excelProcess = new ExcelProcess();

        public async Task<IActionResult> Upload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Upload(IFormFile file)
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
                    //rename file when upload to sever
                    var fileName = DateTime.Now.ToShortTimeString() + fileExtension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", fileName);
                    var fileLocation = new FileInfo(filePath).ToString();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        //save file to server
                        await file.CopyToAsync(stream);
                        //read data from file and write to database
                        var dt = _excelProcess.ExcelToDataTable(fileLocation);
                        //dùng vòng lặp for để đọc dữ liệu dạng hd
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //create a new Student object
                            var TX = new TenXeModel();
                            //set values for attribiutes
                            TX.XeID = dt.Rows[i][0].ToString();
                            TX.TenXe_BienSo = dt.Rows[i][1].ToString();
                            //add oject to context
                            _context.TenXeModel.Add(TX);
                        }
                        //save to database
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View();
        
    }
 }  
}
