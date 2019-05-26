using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
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



    }
}