using EventManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Controllers
{
    public class EventController : Controller
    {
        private readonly EventManagerContext _context = new();

        public async Task<ActionResult> Index()
        {
            var events = await _context.Events
                                       .Include(x => x.Atendees)
                                       .Include(x => x.Venue)
                                       .ToListAsync();
            return View(events);
        }
    }
}
