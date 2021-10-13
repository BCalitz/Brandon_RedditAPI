﻿using Brandon_RedditAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brandon_RedditAPI.Dtos
{
    public class PostDto:CUPostDto
    {
        public string Id { get; set; }
        public string AuthorId { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
        public DateTime PostDate { get; set; }

        public IEnumerable<CommentDto> comments { get; set; }
    }
}
