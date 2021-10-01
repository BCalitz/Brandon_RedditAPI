using Brandon_RedditAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brandon_RedditAPI.Dtos
{
    public class CUCommentDto
    {
        public Guid PostId { get; set; }
        public string Content { get; set; }
    }
}
