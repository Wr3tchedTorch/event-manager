using EventManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Controllers
{
    public class AtendeeController : Controller
    {
        private readonly EventManagerContext _context;

        public AtendeeController(EventManagerContext context) 
        {
            _context = context;
        }

        public async Task<ActionResult> Detail(int id)
        {
            var atendee = await _context.Atendees.Include(e => e.Events).FirstOrDefaultAsync(x => x.Id == id);
            return View(atendee);
        }
    }
}
