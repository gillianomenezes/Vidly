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
            return View();
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

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var movieFormViewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", movieFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var movieFormViewModel = new MovieFormViewModel
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", movieFormViewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var moviedb = _context.Movies.Single(m => m.Id == movie.Id);

                moviedb.Name = movie.Name;
                moviedb.GenreId = movie.GenreId;
                moviedb.NumberInStock = movie.NumberInStock;
                moviedb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}