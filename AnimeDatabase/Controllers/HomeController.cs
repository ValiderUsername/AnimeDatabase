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


        public async Task<IActionResult> IndexAsync()
        {
            var animes = await _context.Animeliste.ToListAsync();
            var characters = await _context.Characterliste.ToListAsync();

            return View((animes, characters));
        }

        public IActionResult Privacy()
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