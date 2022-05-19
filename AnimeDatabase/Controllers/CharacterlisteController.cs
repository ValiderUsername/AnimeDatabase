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
    public class CharacterlisteController : Controller
    {
        private readonly AnimeDatabaseContext _context;

        public CharacterlisteController(AnimeDatabaseContext context)
        {
            _context = context;
        }

        // GET: Characterliste
        public async Task<IActionResult> Index(string searchString)
        {
            var characters = from character in _context.Characterliste
                            select character;

            if (!String.IsNullOrEmpty(searchString))
            {
                characters = characters.Where(s => s.Name!.Contains(searchString));
            }

            return View(await characters.ToListAsync());
        }

        // GET: Characterliste/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Characterliste == null)
            {
                return NotFound();
            }

            var characterliste = await _context.Characterliste
                .FirstOrDefaultAsync(m => m.ID == id);
            if (characterliste == null)
            {
                return NotFound();
            }

            return View(characterliste);
        }

        // GET: Characterliste/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Characterliste/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Alter,Grösse,Rating")] Characterliste characterliste)
        {
            if (ModelState.IsValid)
            {
                _context.Add(characterliste);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(characterliste);
        }

        // GET: Characterliste/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Characterliste == null)
            {
                return NotFound();
            }

            var characterliste = await _context.Characterliste.FindAsync(id);
            if (characterliste == null)
            {
                return NotFound();
            }
            return View(characterliste);
        }

        // POST: Characterliste/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Alter,Grösse,Rating")] Characterliste characterliste)
        {
            if (id != characterliste.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(characterliste);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterlisteExists(characterliste.ID))
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
            return View(characterliste);
        }

        // GET: Characterliste/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Characterliste == null)
            {
                return NotFound();
            }

            var characterliste = await _context.Characterliste
                .FirstOrDefaultAsync(m => m.ID == id);
            if (characterliste == null)
            {
                return NotFound();
            }

            return View(characterliste);
        }

        // POST: Characterliste/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Characterliste == null)
            {
                return Problem("Entity set 'AnimeDatabaseContext.Characterliste'  is null.");
            }
            var characterliste = await _context.Characterliste.FindAsync(id);
            if (characterliste != null)
            {
                _context.Characterliste.Remove(characterliste);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterlisteExists(int id)
        {
          return (_context.Characterliste?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
