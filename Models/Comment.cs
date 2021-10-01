using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brandon_RedditAPI.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        
        public Guid AuthorId { get; set; }
        public string Content { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
        public DateTime CommentDate { get; set; }

        public void upVote()
        {
            Upvotes += 1;
        }

        public void downVote()
        {
            Upvotes += 1;
        }
    }
}
