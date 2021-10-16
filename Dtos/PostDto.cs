using Brandon_RedditAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brandon_RedditAPI.Dtos
{
    public class PostDto:CUPostDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public Votes votes { get; set; }
        public DateTime PostDate { get; set; }

        public IEnumerable<CommentDto> comments { get; set; }
    }
}
