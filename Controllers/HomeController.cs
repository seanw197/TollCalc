using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using TollCalc.Models;

// Sample CA3 - M50 Toll Calculator

namespace TollCalc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        List<SelectListItem> vehicles = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Car", Value = "2.00", Selected = true },
            new SelectListItem() { Text = "Public Service Vehicle", Value = "2.000001" },
            new SelectListItem() { Text = "Bus", Value = "2.80" },
            new SelectListItem() { Text = "Goods", Value = "4.10" }
        };


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
  
        public IActionResult Calculate()
        {
            Vehicle mv = new Vehicle();
            mv.VeList = vehicles;
            return View(mv);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Calculate(Vehicle mv)
        {
            double Price = mv.Toll;

            if(mv.HasTag == true) 
            {
                Price *= 0.8;
            }

            ViewBag.Charge = "Toll Charge for your vehicle is €" + Price.ToString("0.00");
            mv.VeList = vehicles;
            return View(mv);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
