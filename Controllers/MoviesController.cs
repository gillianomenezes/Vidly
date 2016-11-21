using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private List<Movie> Movies = new List<Movie>
        {
            new Movie() { Name = "Shrek", Id = 1 },
            new Movie() { Name = "Wall-e", Id = 2 }
        };
        // GET: Movies
        public ActionResult Index()
        {
            MoviesViewModel viewModel = new MoviesViewModel()
            {
                Movies = this.Movies
            };

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            if(Movies.Exists(x => x.Id == id))
            {
                return View(Movies.First(x => x.Id == id));
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}