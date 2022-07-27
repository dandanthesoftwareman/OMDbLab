using Microsoft.AspNetCore.Mvc;
using OMDBLab.Models;
using System.Diagnostics;

namespace OMDBLab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public MovieDAL movieDAL = new MovieDAL();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]//Run when you first go to page
        public IActionResult MovieSearch()
        {
            return View();
        }
        [HttpPost]//Run when you sumbit your form
        public IActionResult MovieSearch(string title)
        {
            MovieModel movie = movieDAL.GetMovie(title);
            return View(movie);
        }
        [HttpGet]//Run when you first go to page
        public IActionResult MovieNight()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MovieNight(string Title1, string Title2, string Title3)
        {
            List<MovieModel> movies = new List<MovieModel>()
            {
            movieDAL.GetMovie(Title1),
            movieDAL.GetMovie(Title2),
            movieDAL.GetMovie(Title3)
            };
            return View(movies);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}