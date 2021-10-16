using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brandon_RedditAPI.Models
{
    public class Comment
    {
        public string Id { get; set; }
        public string PostId { get; set; }
        public string AuthorId { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }

    }
}
