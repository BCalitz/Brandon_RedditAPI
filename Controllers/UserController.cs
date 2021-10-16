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
        private IDBData _Data;
        public UserController(IDBData postData)
        {
            this._Data = postData;
        }


        // POST ###/api/users/register###
        // Registers a User
        [HttpPost]
        [Route("register")]
        public ActionResult RegisterUser(CUUserDto userData)
        {
            User user = new User()
            {
                Id = "U_" + Guid.NewGuid().GetHashCode(),
                Password = Encoding.UTF8.GetBytes(userData.Password),
                Username = userData.Username,
                APIKey = Guid.NewGuid()
            };
            _Data.AddUser(user);

            return Ok();
        }


        // GET ###/api/users/posts###
        // Gets all posts a user has made
        [HttpGet]
        [Route("posts")]
        public ActionResult<IEnumerable<PostDto>> UserPosts([FromBody] string username)
        {
            var user = _Data.getUser(username);
            if (user is null) { return NotFound($"The user with the Username of: {username} was not found"); }
            return _Data.getUserPosts(user.Id).Select(post => post.AsDto(_Data.getVotes(post.Id))).ToList();
        }

        // GET ###/api/users/getkey###
        // Gets a Users ApiKey
        [HttpGet]
        [Route("getKey")]
        public ActionResult<string> GetKey(LoginDto loginInfo)
        {
            
            var user = _Data.login(loginInfo);
            if (user is null) { return Unauthorized("User does not exist or invalid credentials"); }
            return user.APIKey.ToString();
        }

        // GET ###/api/users/getuser###
        // get a users info
        [HttpGet]
        [Route("getUser")]
        public ActionResult<object> GetUser([FromBody] string Id)
        {

            var user = _Data.getUserFromId(Id);
            if (user is null) { return Unauthorized("User does not exist or invalid credentials"); }
            return new {user.Id, user.Username };
        }

        // GET ###/api/users/myposts###
        // Gets post you have made
        [HttpGet]
        [Route("myPosts")]
        public ActionResult<IEnumerable<PostDto>> UserPosts()
        {
            var user = _Data.isValidAPIKey(Request.Headers["ApiKey"]);
            if (user is null) { return Unauthorized("\"ApiKey\" has no value or invalid"); }

            return _Data.getUserPosts(user.Id).Select(post => post.AsDto(_Data.getVotes(post.Id))).ToList();
        }

        // GET ###/api/users/myactivity###
        // Gets all posts you have upvoted or downvoted
        [HttpGet]
        [Route("myActivity")]
        public ActionResult<IEnumerable<PostDto>> UserActivity()
        {
            var user = _Data.isValidAPIKey(Request.Headers["ApiKey"]);
            if (user is null) { return Unauthorized("\"ApiKey\" has no value or invalid"); }

            return _Data.getUserActivity(user.Id).Select(post => post.AsDto(_Data.getVotes(post.Id))).ToList();
        }
    }
}
