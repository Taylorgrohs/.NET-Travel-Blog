using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TravelBlog.Models;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Mvc.Rendering;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelBlog.Controllers
{
    public class PersonsController : Controller
    {
        private TravelBlogContext db = new TravelBlogContext();

        // GET: /<controller>/
        public IActionResult Create()
        {
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Name");

            ViewBag.ExperienceId = new SelectList(db.Experiences, "ExperienceId", "Description");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            db.Persons.Add(person);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}
