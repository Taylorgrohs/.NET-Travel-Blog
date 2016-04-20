using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TravelBlog.Models;
using Microsoft.Data.Entity;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelBlog.Controllers
{
    public class PersonsController : Controller
    {
        private TravelBlogContext db = new TravelBlogContext();

        // GET: /<controller>/
        public IActionResult Index(int id)
        {
            Dictionary<string, object> myDictionary = new Dictionary<string, object>();
            
            myDictionary.Add("Person", db.Persons.Where(x => x.LocationId == id).ToList());

            myDictionary.Add("Experience", db.Experiences.Where(x => x.ExperienceId == id).ToList());

            return View(myDictionary);
        }

    }
}
