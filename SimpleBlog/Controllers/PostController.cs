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
            //var post = _context.Posts.SingleOrDefault(p => p.Id == id);
            //var comments = _context.Comments.Where(c => c.PostId == id).ToList();

            var detailsModel = new PostViewModel
            {
                Post = _context.Posts.SingleOrDefault(p => p.Id == id),
                Comments = _context.Comments.Where(c => c.PostId == id).ToList()
            };

            if (detailsModel.Post.UserIdentity == User.Identity.GetUserId())
            {
                return View("PostOwnerDetails",detailsModel);
            }

            return View(detailsModel);
        }

        // GET: Post / New

        public ActionResult New()
        {
            var newPost = new Post();

            return View("PostForm", newPost);
        }

        [HttpPost]
        public ActionResult Comment(Comment comment, Post post)
        {
            string currentUserId = User.Identity.GetUserId();

            var currentUserInfo = _context.Users.SingleOrDefault(u => u.Id == currentUserId);

            comment.CommentBy = currentUserInfo.Name;
            comment.CommentDate = DateTime.Today;
            comment.PostId = post.Id;


            _context.Comments.Add(comment);
            _context.SaveChanges();

            return RedirectToAction("Details", "Post", post);
        }

        
        public ActionResult DeleteComment(int id)
        {
            var comment = _context.Comments.SingleOrDefault(c => c.Id == id);

            var postId = comment.PostId;

            var post = _context.Posts.SingleOrDefault(p => p.Id == postId);

            _context.Comments.Remove(comment);
            _context.SaveChanges();

            return RedirectToAction("Details", "Post", post);
        }


        [HttpPost]
        public ActionResult Save(Post post)
        {
            string currentUserId = User.Identity.GetUserId();

            var currentUserInfo = _context.Users.SingleOrDefault(u => u.Id == currentUserId);
       
            post.UserIdentity = User.Identity.GetUserId();
            post.PostedBy = currentUserInfo.Name;
            post.PostDate = DateTime.Today;

            _context.Posts.Add(post);
            _context.SaveChanges();

            return RedirectToAction("Details", "Post", post);
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

            var posts = _context.Posts.Where(p => p.UserIdentity == currentUserId).ToList();

            return View(posts);
        }

        // GET: Post / Delete

        public ActionResult Delete(int id)
        {
            var post = _context.Posts.SingleOrDefault(p => p.Id == id);

            _context.Posts.Remove(post);
            _context.SaveChanges();

            return RedirectToAction("Timeline", "Post");
        }
    }
}