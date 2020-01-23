using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITHS_DB_Lab5.Service;
using Microsoft.AspNetCore.Mvc;

namespace ITHS_DB_Lab5.Controllers
{
    public class CategoryController : Controller
    {
        private readonly PostService postService;

        public CategoryController(PostService postService)
        {
            this.postService = postService;
        }

        public ActionResult Index()
        {
            var clist = postService.GetAllCategories()
                .Where(p => p.Name != null)
                .ToList();
            ViewBag.CategoryList = clist;
            return View();
        }
        public ActionResult PostByCategory(string name)
        {
            return View(postService.GetAllPostsByCategory(name));
        }
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var post = postService.Get(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
    }
}