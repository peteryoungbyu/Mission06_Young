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
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("Movies", new MovieEntry());
        }

        //Handles the post request when a movie is entered
        [HttpPost]
        public IActionResult Movies(MovieEntry response)
        {

            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();
                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
                return View(response);
            }
        }


        //Error handling
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
        public IActionResult MoviesList()
        {
            var movies = _context.Movies
                .OrderBy(x => x.MovieId).ToList();
            return View(movies);
        }

        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("Movies", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(MovieEntry updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("MoviesList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);
            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(MovieEntry movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("MoviesList");
        }

    }
}
