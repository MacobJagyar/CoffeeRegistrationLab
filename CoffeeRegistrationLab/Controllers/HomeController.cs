using CoffeeRegistrationLab.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoffeeRegistrationLab.Controllers
{
    public class HomeController : Controller
    {

        public string Uname { get; set; }
        private readonly ILogger<HomeController> _logger;
        private CoffeeRegistrationLabContext context = new CoffeeRegistrationLabContext();

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

        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult SubmitWelcome(User user)
        {
            return View(user);
        }

        public IActionResult AddUserToDb(User user, string FirstName)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return RedirectToAction("SubmitWelcome", user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}