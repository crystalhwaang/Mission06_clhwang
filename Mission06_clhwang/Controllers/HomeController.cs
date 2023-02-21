using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission06_clhwang.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_clhwang.Controllers
{
    public class HomeController : Controller
    {
        private MovieApplicationContext _movieContext { get; set; }

        public HomeController(MovieApplicationContext x)
        {
            _movieContext = x;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcast()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieApplication()
        {
            ViewBag.Categories = _movieContext.Categories.ToList();
            return View();
        }
        
        [HttpPost]
        public IActionResult MovieApplication(ApplicationResponse ar)
        {
            _movieContext.Add(ar);
            _movieContext.SaveChanges();
            return View("Confirmation", ar);
        }
        [HttpGet]
        public IActionResult Pending()
        {
            var applications = _movieContext.Responses
                .Include(y => y.Category)
                .OrderBy(y => y.Title)
                .ToList();
            return View(applications);
        }
    }
}
