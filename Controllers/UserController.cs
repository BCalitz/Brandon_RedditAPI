using Brandon_RedditAPI.Data;
using Brandon_RedditAPI.Dtos;
using Brandon_RedditAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brandon_RedditAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IPostData _Data;
        public UserController(IPostData postData)
        {
            this._Data = postData;
        }

        [HttpPost]
        [Route("register")]
        public ActionResult RegisterUser(CUUserDto userData)
        {
            User user = new User()
            {
                Id = "U_" + Guid.NewGuid().GetHashCode(),
                Password = Encoding.UTF8.GetBytes(userData.Password),
                Username = userData.Username
            };
            _Data.AddUser(user);

            return Ok(user.Id);
        }


        [HttpGet]
        [Route("posts")]
        public ActionResult<IEnumerable<PostDto>> UserPosts([FromBody] string Id)
        {
            if (_Data.getUser(Id) is null) { return NotFound($"The user with the Id of: {Id} was not found"); }
            return _Data.getUserPosts(Id).Select(post => post.AsDto()).ToList();
        }





    }
}
