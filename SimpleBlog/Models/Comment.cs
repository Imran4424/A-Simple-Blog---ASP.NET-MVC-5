using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Data { get; set; }

        [Required]
        public string CommentBy { get; set; }

        [Required]
        public DateTime CommentDate { get; set; }

        [Required]
        public int PostId { get; set; }
    }
}