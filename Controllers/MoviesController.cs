using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Data.Migrations;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
   // [Route("api/[Controller]")]

    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;
        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var movies = _context.Movies.ToList();
            var viewModel = new Movie();
            {
              
            };
            return View("MovieForm", viewModel);
        }
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.Genre = movie.Genre;
                movieInDb.Stock = movie.Stock;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }


        // [HttpGet]
        public ActionResult Index()
        {
            var movies = _context.Movies.ToList();


            return View(movies);

            //return Json(movies);
        }

        //[HttpGet("{id}")]
        public ActionResult Details(int id)
        {

            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return Content("Not Found");

            return View(movie);

        }

        public ActionResult Edit(int id)
        {

            //we need to get the customer details from the database
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return Content("NOT FOUND");


            var viewModel = new Movie();
            {

                //Movies = movie;

            };

            return View("MovieForm", viewModel);


        }



    }
}