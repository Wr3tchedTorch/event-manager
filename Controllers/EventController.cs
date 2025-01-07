using EventManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Controllers
{
    public class EventController : Controller
    {
        private readonly EventManagerContext _context;

        public EventController(EventManagerContext context) 
        {
            _context = context;
        }

        public async Task<ActionResult> Index()
        {
            var events = await _context.Events
                                       .Include(x => x.Atendees)
                                       .Include(x => x.Venue)
                                       .ToListAsync();
            return View(events);
        }

        public async Task<ActionResult> Detail(int id)
        {
            var @event = await _context.Events
                                       .Include(x => x.Atendees)
                                       .Include(x => x.Venue)
                                       .FirstOrDefaultAsync(x => x.Id == id);
            return View(@event);
        }
    }
}
