using AnimeDatabase.Data;
using AnimeDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace AnimeDatabase.Controllers
{
    public class HomeController : Controller
    {
        private readonly AnimeDatabaseContext _context;

        public HomeController(AnimeDatabaseContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> IndexAsync(string sortAnime, string sortCharacter)
        {
            var animes = await _context.Animeliste.ToListAsync();
            var characters = await _context.Characterliste.ToListAsync();

            ViewBag.AnimeSort = String.IsNullOrEmpty(sortAnime) ? "title_desc" : "";
            ViewBag.CharacterSort = String.IsNullOrEmpty(sortCharacter) ? "name_desc" : "";

            //Sortierung für Animes
            var anime = from a in _context.Animeliste
                        select a;

            switch (sortAnime)
            {
                case "title_desc":
                    anime = anime.OrderByDescending( a => a.Title);
                    break;
                default:
                    anime = anime.OrderBy(a => a.Title);
                    break;
            }
            //Sortierung für Character
            var character = from c in _context.Characterliste
                            select c;
            switch (sortCharacter)
            {
                case "name_desc":
                    character = character.OrderByDescending(c => c.Name);
                    break;
                default:
                    character = character.OrderBy(c => c.Name);
                    break;
            }


            return View((anime.ToList(), character.ToList()));
        }
        public IActionResult Ersteller()
        {
            return View();
        }

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}