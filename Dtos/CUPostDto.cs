using Brandon_RedditAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brandon_RedditAPI.Dtos
{
    //Dto for Creating adn updating a post
    public class CUPostDto
    {
        public string Title { get; set; }
        public string[] Tags { get; set; }
        public string Content { get; set; }

    }
}
