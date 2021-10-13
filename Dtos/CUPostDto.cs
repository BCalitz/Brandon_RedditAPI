using Brandon_RedditAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Brandon_RedditAPI.Dtos
{
    //Dto for Creating adn updating a post
    public class CUPostDto
    {
        [Required]
        public string Title { get; set; }
        public string Tags { get; set; }
        [Required]
        public string Content { get; set; }

    }
}
