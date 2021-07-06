using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GC_Car_Dealership.Models;
using System.Diagnostics;


namespace GC_Car_Dealership.Controllers
{

    //Started working on a home controller and add views, but have not yet been successful.
    public class HomeController : Controller
    {
        CarsDBContext db = new CarsDBContext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(string searchType, string input)
        {
            
            return View();
        }
    }
}
