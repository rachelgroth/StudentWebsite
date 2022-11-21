using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentWebsite.Data;
using StudentWebsite.Models;
using static System.Collections.Specialized.BitVector32;

namespace StudentWebsite.Controllers
{
    public class SectionsController : Controller
    {
        private readonly StudentWebsiteContext _context;

        public SectionsController(StudentWebsiteContext context)
        {
            _context = context;
        }

        // GET: Sections
        public async Task<IActionResult> Index()
        {
            var sections = _context.Section
                .Include(s => s.Course)
                .Include(s => s.Registrations);
            return View(await sections.ToListAsync());
        }

        // GET: Sections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Section == null)
            {
                return NotFound();
            }

            var section = await _context.Section
                .Include(s => s.Course)
                .Include(s => s.Registrations)
                    .ThenInclude(r => r.Student)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (section == null)
            {
                return NotFound();
            }

            return View(section);
        }

        // GET: Sections/Create
        public IActionResult Create()
        {
            PopulateCourseDropDownList();
            return View();
        }

        // POST: Sections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CourseID,TotalSpots,Professor")] Models.Section sect)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sect);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateCourseDropDownList(sect.CourseID);
            return View(sect);
        }

        // GET: Sections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Section == null)
            {
                return NotFound();
            }

            var section = await _context.Section.FindAsync(id);
            if (section == null)
            {
                return NotFound();
            }
            PopulateCourseDropDownList(section.CourseID);
            return View(section);
        }

        // POST: Sections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CourseID,TotalSpots,Professor")] Models.Section sect)
        {
            if (id != sect.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sect);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SectionExists(sect.ID))
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
            PopulateCourseDropDownList(sect.CourseID);
            return View(sect);
        }

        // GET: Sections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Section == null)
            {
                return NotFound();
            }

            var section = await _context.Section
                .FirstOrDefaultAsync(m => m.ID == id);
            if (section == null)
            {
                return NotFound();
            }

            return View(section);
        }

        // POST: Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Section == null)
            {
                return Problem("Entity set 'StudentWebsiteContext.Section'  is null.");
            }
            var section = await _context.Section.FindAsync(id);
            if (section != null)
            {
                _context.Section.Remove(section);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SectionExists(int id)
        {
            return (_context.Section?.Any(e => e.ID == id)).GetValueOrDefault();
        }

        private void PopulateCourseDropDownList(object selectedCourse = null)
        {
            var courseQuery = from c in _context.Course
                              orderby c.ID
                              select c;
            ViewBag.CourseID = new SelectList(courseQuery, "ID", "CourseCode", selectedCourse);
        }
    }
}
