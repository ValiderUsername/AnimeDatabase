using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AnimeDatabase.Data;
using AnimeDatabase.Models;

namespace AnimeDatabase.Controllers
{
    public class AnimelistenController : Controller
    {
        private readonly AnimeDatabaseContext _context;

        public AnimelistenController(AnimeDatabaseContext context)
        {
            _context = context;
        }

        // GET: Animelisten
        public async Task<IActionResult> Index(string searchString)
        {
            var animes = from anime in _context.Animeliste
                         select anime;

            if (!String.IsNullOrEmpty(searchString))
            {
                animes = animes.Where(s => s.Title!.Contains(searchString));
            }

            return View(await animes.ToListAsync());
        }
        // GET: Animelisten/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Animeliste == null)
            {
                return NotFound();
            }

            var animeliste = await _context.Animeliste
                .FirstOrDefaultAsync(m => m.ID == id);
            if (animeliste == null)
            {
                return NotFound();
            }

            return View(animeliste);
        }

        // GET: Animelisten/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Animelisten/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Genre,Episoden,ReleaseDate")] Animeliste animeliste)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animeliste);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animeliste);
        }

        // GET: Animelisten/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Animeliste == null)
            {
                return NotFound();
            }

            var animeliste = await _context.Animeliste.FindAsync(id);
            if (animeliste == null)
            {
                return NotFound();
            }
            return View(animeliste);
        }

        // POST: Animelisten/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Genre,Episoden,ReleaseDate")] Animeliste animeliste)
        {
            if (id != animeliste.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animeliste);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimelisteExists(animeliste.ID))
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
            return View(animeliste);
        }

        // GET: Animelisten/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Animeliste == null)
            {
                return NotFound();
            }

            var animeliste = await _context.Animeliste
                .FirstOrDefaultAsync(m => m.ID == id);
            if (animeliste == null)
            {
                return NotFound();
            }

            return View(animeliste);
        }

        // POST: Animelisten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Animeliste == null)
            {
                return Problem("Entity set 'AnimeDatabaseContext.Animeliste'  is null.");
            }
            var animeliste = await _context.Animeliste.FindAsync(id);
            if (animeliste != null)
            {
                _context.Animeliste.Remove(animeliste);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimelisteExists(int id)
        {
          return (_context.Animeliste?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
