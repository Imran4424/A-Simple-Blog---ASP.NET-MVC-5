using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleBlog.Controllers
{
    public class PostController : Controller
    {
        // GET: Controller / Index 
        public ActionResult Index()
        {
            return View();
        }
    }
}