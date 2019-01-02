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
            return View();
        }
    }
}