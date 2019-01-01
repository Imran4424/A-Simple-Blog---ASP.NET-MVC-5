using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public DateTime PostDate { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string UserIdentity { get; set; }
    }
}