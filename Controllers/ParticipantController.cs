using System.Linq;
using Microsoft.AspNetCore.Mvc;
using powerplatformevents.Models;

namespace powerplatformevents.Controllers
{
    public class ParticipantController : Controller
    {
        private readonly ppeventsContext _dbContext;

        public ParticipantController(ppeventsContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToActionPermanent("index", "home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Participants participant)
        {
                try
                {
                    var part = _dbContext.Participants.FirstOrDefault(p => p.EmailAddress == participant.EmailAddress || p.PhoneNumber == participant.PhoneNumber);
                    if (part == null)
                    {
                        _dbContext.Participants.Add(new Participants
                        {
                            EmailAddress = participant.EmailAddress,
                            Name = participant.Name,
                            PhoneNumber = participant.PhoneNumber,
                            EventId = 9
                        });

                        TempData.Add("Registered", new MessageViewModel { CssClassName = "alert-sucess", Title = "Success!", Message = "You have been registered successfully. We do not send email confirmations" });
                        _dbContext.SaveChanges();
                    }
                }
                catch
                {
                    TempData.Add("Registered", new MessageViewModel() { CssClassName = "alert-error", Title = "Error!", Message = "Registration failed, please try again later (or tweet @crmviking if this has been going on for a while)." });
                }

                return RedirectToActionPermanent("index", "home");
        }
    }
}