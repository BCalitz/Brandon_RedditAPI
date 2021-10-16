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
    public class CommentsController : Controller
    {
        private IDBData _Data;
        public CommentsController(IDBData dbData)
        {
            this._Data = dbData;
        }

        // GET ###/api/comments###
        // Gets all comments
        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<CommentDto>> GetComments([FromBody] string Id)
        {
            //ApiKey Authentication
            var post = _Data.getPost(Id);
            if (post is null) { return NotFound($"The post with the Id of: {Id} was not found"); }

            var comments = _Data.getComments(Id);
            return comments.Select(comment => comment.AsDto(_Data.getVotes(Id))).ToList();
        }


        // Post ###/api/comments###
        // Adds a comment
        [HttpPost]
        [Route("")]
        public ActionResult CommentPost(CUCommentDto commentdata)
        {

            var user = _Data.isValidAPIKey(Request.Headers["ApiKey"]);
            if (user is null) { return Unauthorized("\"ApiKey\" has no value or invalid"); }

            var post = _Data.getPost(commentdata.PostId);
            if (post is null) { return NotFound($"The post with the Id of: {commentdata.PostId} was not found"); }



            var comment = new Comment()
            {
                Id = "C_" + Guid.NewGuid().GetHashCode(),
                PostId = commentdata.PostId,
                UserId = user.Id,
                Content = commentdata.Content,
                CommentDate = DateTime.Now
            };

            _Data.addComment(comment);



            return Ok("Created Comment");
        }

        // Post ###/api/comments/{Id}###
        // Edits a comment
        [HttpPut]
        [Route("{Id}")]
        public ActionResult<CommentDto> UpdateComment(string Id, CUCommentDto commentdata)
        {


            var exComment = _Data.getComment(Id);
            if (exComment is null) { return NotFound($"The Comment with the Id of: {Id} was not found"); }

            var user = _Data.isValidAPIKey(Request.Headers["ApiKey"]);
            if (user.Id != exComment.UserId) { return Unauthorized("\"ApiKey\" has no value or invalid"); }



            _Data.updateComment(Id, commentdata);

            return Ok("Edit Successfull");
        }


    }
}
