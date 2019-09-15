using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MecBusca.Models;

namespace MecBusca.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
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

        // HomeController.cs
        public IActionResult Search(String q)
        {
            ViewData["Message"] = "Search page.";
            var da = new DataAccess();
            ViewData["Count"] = da.CountClientes();

            if (!String.IsNullOrEmpty(q))
            {
                return View(da.GetClientes(q));
            }

            return View();
        }
    }
}
