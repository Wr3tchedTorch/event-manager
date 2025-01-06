using EventManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventManagerContext _context = new();

        public async Task<ActionResult> Index()
        {
            var events = await _context.Events.ToListAsync();
            return View(events);
        }
    }
}
