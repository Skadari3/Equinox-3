using Microsoft.AspNetCore.Mvc;
using Equinox.Models;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Equinox.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClubController : Controller
    {
        private readonly EquinoxContext _context;
        private readonly ILogger<ClubController> _logger;

        public ClubController(ILogger<ClubController> logger, EquinoxContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("🔍 Reached Admin/Club/Index action");
            var clubs = _context.Clubs.ToList();
            return View(clubs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Club club)
        {
            if (!ModelState.IsValid)
            {
                return View(club);
            }

            _context.Clubs.Add(club);
            _context.SaveChanges();

            TempData["Message"] = "Club created successfully.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var club = _context.Clubs.Find(id);
            if (club == null)
            {
                return NotFound();
            }
            return View(club);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Club club)
        {
            if (!ModelState.IsValid)
            {
                return View(club);
            }

            _context.Clubs.Update(club);
            _context.SaveChanges();

            TempData["Message"] = "Club updated successfully.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var club = _context.Clubs.Find(id);
            if (club == null)
            {
                return NotFound();
            }
            return View(club);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var club = _context.Clubs.Find(id);
            if (club != null)
            {
                _context.Clubs.Remove(club);
                _context.SaveChanges();
                TempData["Message"] = "Club deleted successfully.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
