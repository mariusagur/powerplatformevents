using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using powerplatformevents.Models;
using System.Linq;

namespace powerplatformsaturday.Controllers
{
    public class SessionController : Controller
    {
        private readonly ppeventsContext _context;

        public SessionController(ppeventsContext context)
        {
            _context = context;
        }

        [Route("Session/Index/{id}")]
        public IActionResult Index(int id)
        {
            var session = _context.Sessions.Include(s => s.Speaker).FirstOrDefault(s => s.Id == id);

            if (session == null)
            {
                return NotFound($"No session with id {id} found");
            }
            return View(session);
        }

        [Route("Session")]
        public IActionResult Index()
        {
            return Redirect("/");
        }
    }
}