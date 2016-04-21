using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelBlog.Models;


namespace TravelBlog.ViewComponents
{
    public class PersonView : ViewComponent
    {
        private readonly TravelBlogContext db;

        public PersonView(TravelBlogContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id, string name)
        {
            var persons = await GetPersonsAsync(id, name);
            return View(persons);
        }

        private Task<List<Person>> GetPersonsAsync(int id, string name)
        {
            return db.Persons.Include(x => x.Name).ToListAsync();
        }
    }
}
