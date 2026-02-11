//Peter Young section 1
//Home controller that sends the user to different pages and also handles the "post" for entered movies

using Microsoft.AspNetCore.Mvc;
using Mission06_Young.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Mission06_Young.Controllers
{
    public class HomeController : Controller
    {

        //Context file information
        private MovieEntryContext _context;

        public HomeController(MovieEntryContext temp) //Constructor
        {
            _context = temp;
        }

        //Can render the index
        public IActionResult Index()
        {
            return View();
        }

        //Renders the "About" page
        public IActionResult About()
        {
            return View();
        }

        //Renders the Movies page
        [HttpGet]
        public IActionResult Movies()
        {
            return View();
        }

        //Handles the post request when a movie is entered
        [HttpPost]
        public IActionResult Movies(MovieEntry response)
        {
            _context.Movies.Add(response); // Adds record to database
            _context.SaveChanges();
            return View("Confirmation", response);
        }


        //Error handling
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
