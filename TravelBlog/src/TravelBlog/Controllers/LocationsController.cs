﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TravelBlog.Models;
using Microsoft.Data.Entity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelBlog.Controllers
{
    public class LocationsController : Controller
    {

        private TravelBlogContext db = new TravelBlogContext();

       
        public IActionResult Index()
        {
            return View(db.Locations.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Location location)
        {
            db.Locations.Add(location);
            db.SaveChanges();
            return RedirectToAction("Create", "Experiences");
        }
        public IActionResult Edit(int id)
        {
            var thisLocation = db.Locations.FirstOrDefault(x => x.LocationId == id);
            return View(thisLocation);
        }
        [HttpPost]
        public IActionResult Edit(Location location)
        {
            db.Entry(location).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisLocation = db.Locations.FirstOrDefault(x => x.LocationId == id);
            return View(thisLocation);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisLocation = db.Locations.FirstOrDefault(x => x.LocationId == id);
            db.Locations.Remove(thisLocation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }      

        public IActionResult LocationExperience(int id)
        {
            var LocationExperiences = db.Experiences.Where(x => x.LocationId == id).ToList();
            return View(LocationExperiences);
        }

        public IActionResult LocationPeople(int id)
        {
            var LocationPersons = db.Persons.Where(x => x.LocationId == id).Include(x => x.experience).Include(x => x.location).ToList();
            return View(LocationPersons);
        }

        public IActionResult LocationPeopleVC()
        {
            return ViewComponent("LocationPeople", 3, false);
        }
    }
}
