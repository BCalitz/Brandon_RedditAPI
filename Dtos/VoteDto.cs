using Brandon_RedditAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Brandon_RedditAPI.Dtos
{
    //Dto for Creating adn updating a post
    public class VoteDto
    {
        [Required]
        public string thingId { get; set; }
        [Required]
        [Range(-1,1)]
        public int rating { get; set; }

    }
}
