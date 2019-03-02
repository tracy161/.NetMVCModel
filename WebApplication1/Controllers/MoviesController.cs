using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;


namespace WebApplication1.Controllers
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

        public ActionResult New()
        {
            var Genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Genres = Genres
            };
            return View("MovieForm", viewModel);
        }

        //update data by manual setting the properties of the customer object (movieInDb)
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);

             else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                //update properties
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;

             }
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Movies");
        }
        // GET: Movies
        public ViewResult Index()
        {
            // declare variable customer and list of movies
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }


        public ActionResult Details(int id)
        {
            // use _context method to get reference source from the list customer
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()

            };

            return View("MovieForm", viewModel);
        }

    }
}