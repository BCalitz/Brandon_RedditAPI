using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brandon_RedditAPI.Models
{
    public class User
    { 
        public string Id { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public Guid APIKey { get; set; }


    }
}
