using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBlog.Models
{
    public class PostViewModel
    {
        public Post Post { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}