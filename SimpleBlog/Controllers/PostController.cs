﻿using System;
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

        // GET: Controller / Index 
        public ActionResult Index()
        {
            return View();
        }
    }
}