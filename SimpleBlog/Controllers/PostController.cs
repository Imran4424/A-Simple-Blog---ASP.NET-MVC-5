using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using SimpleBlog.Models;

namespace SimpleBlog.Controllers
{
    public class PostController : Controller
    {
        private ApplicationDbContext _context;

        public PostController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Post / Index 
        public ActionResult Index()
        {
            var posts = _context.Posts.ToList();

            return View(posts);
        }

        
        // GET: Post / Details
        
        public ActionResult Details(int id)
        {
            var post = _context.Posts.SingleOrDefault(p => p.Id == id);

            return View(post);
        }

        // GET: Post / New

        public ActionResult New()
        {
            var newPost = new Post();

            return View("PostForm", newPost);
        }

        [HttpPost]
        public ActionResult Save(Post post)
        {
            post.UserIdentity = User.Identity.GetUserId();
            post.UserName = User.Identity.Name;
            post.PostDate = DateTime.Now;

            _context.Posts.Add(post);
            _context.SaveChanges();

            return RedirectToAction("Index", "Post");
        }


        // GET: Post / Edit

        public ActionResult Edit(int id)
        {
            var post = _context.Posts.SingleOrDefault(p => p.Id == id);

            return View("UpdateForm", post);
        }

        [HttpPost]
        public ActionResult Update(Post post)
        {
            var postInDb = _context.Posts.Single(c => c.Id == post.Id);

            postInDb.Title = post.Title;
            postInDb.Body = post.Body;

            _context.SaveChanges();


            return RedirectToAction("Details", "Post", postInDb);
        }


        // GET: Post / Edit

        public ActionResult Timeline()
        {
            string currentUserId = User.Identity.GetUserId();
        }
    }
}