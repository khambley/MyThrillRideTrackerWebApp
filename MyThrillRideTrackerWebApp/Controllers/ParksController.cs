using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using MyThrillRideTrackerWebApp.Models;

namespace MyThrillRideTrackerWebApp.Controllers
{
    public class ParksController : Controller
    {
        private readonly DataContext _context;

        public ParksController(DataContext context)
        {
            _context = context;
        }

        // GET: Parks
        public async Task<IActionResult> Index()
        {
            // Can't use ToListAsync with var or List<Park> -> must be IEnumerable<Park> or IQueryable<Park>
            // because they implement the GetEnumerator iterator method 12/28/20 KLH
            IEnumerable<Park> parksList = await _context.Parks.Include(p => p.ImageFiles).ToListAsync();
            //var imageList = new List<ImageFileName>();
            
            //foreach (var park in parksList)
            //{
            //    imageList.Add(_context.ImageFileNames
            //        .FirstOrDefault(i => i.ParkId == park.Id));
            //    park.ImageFiles = imageList;

            //}
            
            return View(parksList);
        }

        // GET: Parks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var park = await _context.Parks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (park == null)
            {
                return NotFound();
            }

            return View(park);
        }

        // GET: Parks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("City,State,Id,Name,Description")] Park park, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            { 
                // 1. Save the park model first, creates a unique id for the inserted park.
                _context.Add(park);
                await _context.SaveChangesAsync();

                // 2. Save the ImageFiles in Images folder and FileName in db.
                await SaveParkImageFiles(park, files);

                return RedirectToAction(nameof(Index));
            }
            return View(park);
        }

        // GET: Parks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var park = await _context.Parks.FindAsync(id);
            if (park == null)
            {
                return NotFound();
            }
            return View(park);
        }

        // POST: Parks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("City,State,Id,Name,Description")] Park park, List<IFormFile> files)
        {
            if (id != park.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // 1. Update the park model first, finds unique id for the inserted park and updates it.
                    _context.Update(park);
                    await _context.SaveChangesAsync();

                    // 2. If files is not null, save the ImageFiles in Images folder and FileName in db.
                    await SaveParkImageFiles(park, files);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkExists(park.Id))
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
            return View(park);
        }

        // GET: Parks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var park = await _context.Parks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (park == null)
            {
                return NotFound();
            }

            return View(park);
        }

        // POST: Parks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var park = await _context.Parks.FindAsync(id);
            _context.Parks.Remove(park);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkExists(int id)
        {
            return _context.Parks.Any(e => e.Id == id);
        }

        private async Task SaveParkImageFiles(Park park, List<IFormFile> files)
        {
            if (files != null)
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        //Getting FileName
                        var fileName = Path.GetFileName(file.FileName);

                        //Assigning Unique Filename (Guid)
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        //Getting file Extension
                        var fileExtension = Path.GetExtension(fileName);

                        // concatenating  FileName + FileExtension
                        var newFileName = String.Concat(myUniqueFileName, fileExtension);

                        // Combines two strings into a path.
                        var filepath =
                            new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images")).Root + $@"\{newFileName}";

                        using (FileStream fs = System.IO.File.Create(filepath))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }

                        var imageFileName = new ImageFileName()
                        {
                            FileName = newFileName,
                            ParkId = park.Id
                        };
                        _context.ImageFileNames.Add(imageFileName);
                        await _context.SaveChangesAsync();
                    }
                }
            }
        } // end SaveImageFiles
    }
}
