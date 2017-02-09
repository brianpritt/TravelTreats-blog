using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelTreats.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelTreats.Controllers
{
    public class PersonsController : Controller
    {
        private TravelTreatsDbContext db = new TravelTreatsDbContext();
        // GET: /<controller>/
        public ActionResult Create(int id)
        {
            ViewBag.experienceId = id;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Person person)
        {
            db.Persons.Add(person);
            db.SaveChanges();
            return RedirectToAction("Index", "Experiences");
        }
    }
}
