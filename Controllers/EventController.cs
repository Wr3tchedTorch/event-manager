using EventManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public ActionResult Create() 
        {
            ViewData["Venues"]   = new SelectList(_context.Venues, "Id", "Name");
            ViewData["Atendees"] = new SelectList(_context.Atendees, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create([Bind("Id, Title, Date, Description, VenueId, OrganizerId")] Event myEvent, List<int> atendeesId) 
        {            
            if (ModelState.IsValid) 
            {
                await _context.Events.AddAsync(myEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction("index");
            }
            return View(myEvent);
        }
    }
}
