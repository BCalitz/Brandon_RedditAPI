using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brandon_RedditAPI.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public string Content { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
        public DateTime PostDate { get; set; }
        public string Title { get; set; }
        public string[] Tags { get; set; }

    }
}
