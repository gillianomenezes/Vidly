using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if(movie != null)
            {
                return View(movie);
            }
            else
            {
                return HttpNotFound();
            }
        }

        private IEnumerable<Movie> GetMovies()
        {
            var movies = _context.Movies;

            return movies;
        }

        public ActionResult New()
        {
            var movieFormView = new MovieFormViewModel
            {
                Genres = _context.Genres
            };

            return View("MovieForm", movieFormView);
        }

        public ActionResult Save()
        {
            return View();
        }
    }
}