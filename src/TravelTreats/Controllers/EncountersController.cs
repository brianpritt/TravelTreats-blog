using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelTreats.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelTreats.Controllers
{
    public class EncountersController : Controller
    {
        private TravelTreatsDbContext db = new TravelTreatsDbContext();

        // GET: /<controller>/
        public ActionResult Index()
        {
            var encounterList = db.Encounters
                .Include(encounters => encounters.Experience)
                .ThenInclude(experiences => experiences.MealType)
                .Include(encounters => encounters.Persons).ToList();
           
            return View(encounterList);
        }
        public IActionResult Create()
        {
            ViewBag.PersonId = new SelectList(db.Persons, "PersonId", "PersonName");
            ViewBag.ExperienceId = new SelectList(db.Experiences, "ExperienceId", "Description");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Encounter encounter)
        {
            db.Encounters.Add(encounter);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
