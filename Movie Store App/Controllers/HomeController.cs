using Microsoft.AspNetCore.Mvc;
using Movie_Store_App.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace Movie_Store_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //Generate a Session here
            var customer = new Customer() { Id = 1, Firstname = "sessionFname", Lastname = "sessionLname" };
            HttpContext.Session.SetString("CustomerIdSession", JsonConvert.SerializeObject(customer));
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}