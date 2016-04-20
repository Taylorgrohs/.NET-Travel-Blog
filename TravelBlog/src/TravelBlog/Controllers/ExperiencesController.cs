using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TravelBlog.Models;
using Microsoft.Data.Entity;



namespace TravelBlog.Controllers
{
    public class ExperiencesController : Controller
    {

        private TravelBlogContext db = new TravelBlogContext();

       
        public IActionResult Index()
        {
            return View();
        }
    }
}
