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
            if (ModelState.IsValid)
            {
                _movieContext.Add(ar);
                _movieContext.SaveChanges();
                return View("Confirmation", ar);
            }
            else
            {
                ViewBag.Categories = _movieContext.Categories.ToList();
                return View(ar);
            }
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
        [HttpGet]
        public IActionResult Edit(int applicationid)
        {
            ViewBag.Categories = _movieContext.Categories.ToList();
            var application = _movieContext.Responses.Single(y => y.ApplicationId == applicationid);
            return View("MovieApplication", application);
        }
        [HttpPost]
        public IActionResult Edit(ApplicationResponse edit)
        {
            _movieContext.Update(edit);
            _movieContext.SaveChanges();
            return RedirectToAction("Pending");
        }
        [HttpGet]
        public IActionResult Delete(int applicationid)
        {
            var application = _movieContext.Responses.Single(y => y.ApplicationId == applicationid);
            return View(application);
        }
        [HttpPost]
        public IActionResult Delete(ApplicationResponse delete)
        {
            _movieContext.Responses.Remove(delete);
            _movieContext.SaveChanges();
            return RedirectToAction("Pending");
        }
    }
}
