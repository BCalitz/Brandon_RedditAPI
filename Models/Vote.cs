using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Brandon_RedditAPI.Models
{
    public class Vote
    {
        public string Id{ get; set; }
        public string AuthorId { get; set; }
        public string ThingId{ get; set; }
        public int vote{ get; set; }

    }
}
