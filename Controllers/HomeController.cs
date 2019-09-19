using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using powerplatformevents.Models;

namespace powerplatformevents.Controllers
{
    public class HomeController : Controller
    {
        private readonly ppeventsContext _dbContext;

        public HomeController(ppeventsContext context)
        {
            _dbContext = context;
        }


        public IActionResult Index()
        {
            var sessions = _dbContext.Sessions.Include(s => s.Speaker).Include(s => s.Event).Where(s => s.EventId == 9);

            var sessionModel = new Dictionary<int, Dictionary<int, Sessions>>();

            sessions.ForEachAsync(s =>
            {
                if (!sessionModel.ContainsKey(s.Timeslot))
                {
                    sessionModel.Add(s.Timeslot, new Dictionary<int, Sessions>());
                }
                sessionModel[s.Timeslot].Add(s.Track, s);
            }).Wait();

            return View(sessionModel);
        }

        public IActionResult Stockholm2019()
        {
            return Redirect("https://www.365portal.org/events/event/?id=33192206-bc70-e911-a991-00224800ce20");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Sponsorship()
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
