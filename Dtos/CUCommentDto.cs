using Brandon_RedditAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Brandon_RedditAPI.Dtos
{
    public class CUCommentDto
    {
        [Required]
        public string PostId { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
