using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITHS_DB_Lab5.Models;
using ITHS_DB_Lab5.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITHS_DB_Lab5.Controllers
{
    public class PostController : Controller
    {
        private readonly PostService postService;

        public PostController(PostService postService)
        {
            this.postService = postService;
        }
        // GET: Post
        public ActionResult Index()
        {
            return View(postService.Get());
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                postService.Create(post);
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Post post)
        {
            if(id != post.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                postService.Update(id, post);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(post);
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(string id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var post = postService.Get(id);
            if(post == null)
            {
                return NotFound();
            }
            return View();
        }

        // POST: Post/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}