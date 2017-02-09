using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelTreats.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TravelTreats.Controllers
{
    public class ExperiencesController : Controller
    {
        private TravelTreatsDbContext db = new TravelTreatsDbContext();
        public IActionResult Index()
        {
            return View(db.Experiences.Include(experiences => experiences.Locations).ToList());
        }
        public IActionResult Details(int id)
        {
            var thisExperieince = db.Experiences
                .Include(experiences => experiences.Locations)
                .Include(experiences => experiences.MealType)
                .FirstOrDefault( experiences => experiences.ExperienceId == id);
            return View(thisExperieince);
        }
        public ActionResult Create()
        {
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "LocationName");
 
            ViewBag.MealTypeId = new SelectList(db.MealTypes, "MealTypeId", "MealTypeName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Experience experience)
        {
            db.Experiences.Add(experience);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var thisExperience = db.Experiences.FirstOrDefault(experience => experience.ExperienceId == id);
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "LocationName");

            ViewBag.MealTypeId = new SelectList(db.MealTypes, "MealTypeId", "MealTypeName");
            return View(thisExperience);
        }
        [HttpPost]
        public ActionResult Update(Experience experience)
        {
            db.Entry(experience).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index"); 
        }
        public ActionResult Delete(int id)
        {
            var thisExperience = db.Experiences.FirstOrDefault(experiences => experiences.ExperienceId == id);
            return View(thisExperience);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisExperience = db.Experiences.FirstOrDefault(experiences => experiences.ExperienceId == id);
            db.Experiences.Remove(thisExperience);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
