using Microsoft.AspNetCore.Mvc;
using WebApplication1.ViewModels;
using WebApplication1.Models;
using WebApplication1.Services;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private SqlPersonData _personData;
        private WebApplication1DbContext _context;

        public HomeController(SqlPersonData personData, WebApplication1DbContext context)
        {
            _personData = personData;
            _context = context;
        }
       
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index(string returnUrl = "")
        {
            var model = new HomePageViewModel { ReturnUrl = returnUrl };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(HomePageViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(model.ReturnUrl) &&
                    Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                } else
                {
                    var person = new Person
                    {
                        Name = model.Name,
                        NewName = model.NewName()
                    };

                    _personData.Add(person);
                    _personData.Commit();
                    model.Name = model.NewName();
                    
                }
            }
            return View(model);
        }

        public IActionResult Search()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [HttpPost]
        public IActionResult Search(SearchNameViewModel model)
        {
            var persons = from p in _context.Persons
                          select p;

            List<Person> sortedList = new List<Person>();

            if(!string.IsNullOrEmpty(model.Name))
            {
                persons = persons.Where(s => s.Name.StartsWith(model.Name));
                sortedList = persons.ToList();
            }
            
            model.PersonSearch = sortedList;
            return View(model);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
