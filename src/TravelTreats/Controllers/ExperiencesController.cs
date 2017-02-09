using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelTreats.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TravelTreats.Controllers
{
    public class ExperiencesController : Controller
    {
        private TravelTreatsDbContext db = new TravelTreatsDbContext();
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "LocationName");
            ViewBag.PersonId = new SelectList(db.Persons, "PersonId", "PersonName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Experience experience)
        {
            db.Experiences.Add(experience);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
