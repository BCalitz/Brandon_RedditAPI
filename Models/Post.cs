using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brandon_RedditAPI.Models
{
    public class Post: Comment
    {
        public string Title { get; set; }
        public string[] Tags { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
