using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ITHS_DB_Lab5.Models;
using ITHS_DB_Lab5.Service;

namespace ITHS_DB_Lab5.Controllers
{
    public class HomeController : Controller
    {
        private readonly PostService postService;

        public HomeController(PostService postService)
        {
            this.postService = postService;
        }

        public IActionResult Index()
        {
            return View(postService.Get().OrderBy(p => p.DateCreated).Take(5));
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
