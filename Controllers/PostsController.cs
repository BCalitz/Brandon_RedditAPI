using Brandon_RedditAPI.Data;
using Brandon_RedditAPI.Dtos;
using Brandon_RedditAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brandon_RedditAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostData _Data;

        public PostsController(IPostData data)
        {
            _Data = data;
        }
        // GET ###/api/posts/###
        //Looks through all Posts
        [HttpGet]
        [Route("")]
        public IEnumerable<PostDto> GetPosts()
        {
            var posts = _Data.getPosts().Select(post => post.AsDto(_Data.getVotes(post.Id)));
            return posts;
        }

        // GET ###/api/posts/{Id}###
        //Selects a Post
        [HttpGet]
        [Route("{Id}")]
        public ActionResult<PostDto> GetPost(string Id)
        {
            var post = _Data.getPost(Id);
            if(post is null) { return NotFound($"The post with the Id of: {Id} was not found"); }
            var comments = _Data.getComments(Id).Select(c => c.AsDto(_Data.getVotes(c.Id)));
            return post.AsDto(comments, _Data.getVotes(post.Id));
        }

        // POST ###/api/posts/###
        //Create a post
        [HttpPost]
        [Route("")]
        public ActionResult<PostDto> AddPost(PostDto postdata)
        {
            var user = _Data.isValidAPIKey(Request.Headers["ApiKey"]);
            if (user is null) { return Unauthorized("\"ApiKey\" has no value or invalid"); }
            Post post = new Post()
            {
                Id = "P_"+Guid.NewGuid().GetHashCode(),
                AuthorId = user.Id,
                Title = postdata.Title,
                Content = postdata.Content,
                Tags = postdata.Tags,
                PostDate = DateTime.Now

            };

            _Data.addPost(post);

            return Created(HttpContext.Request.Scheme = "://" + HttpContext.Request.Host + "/" + post.Id, post);
        }


        // PUT ###/api/posts/{Id}###
        //Edits the Post
        [HttpPut]
        [Route("{Id}")]
        public ActionResult<PostDto> UpdatePost(string Id, CUPostDto postdata)
        {

            var post = _Data.getPost(Id);
            if ( post is null) { return NotFound($"The post with the Id of: {Id} was not found"); }

            var user = _Data.isValidAPIKey(Request.Headers["ApiKey"]);
            if (user.Id != post.AuthorId) { return Unauthorized("\"ApiKey\" has no value or invalid"); }


            _Data.updatePost(Id, postdata);

            return Ok("Edit Successfull");
        }

        // DELETE ###/api/posts/{Id}###
        //Edits the Post
        [HttpDelete]
        [Route("{Id}")]
        public ActionResult DeletePost(string Id)
        {
            var post = _Data.getPost(Id);
            if (post is null) { return NotFound($"The post with the Id of: {Id} was not found"); }

            var user = _Data.isValidAPIKey(Request.Headers["ApiKey"]);
            if (user.Id != post.AuthorId) { return Unauthorized("\"ApiKey\" has no value or invalid"); }

            _Data.deletePost(Id);
            return Ok("Deleted Post");
        }

        // Post ###/api/posts/vote###
        //Edits the Post
        [HttpPost]
        [Route("vote")]
        public ActionResult VotePost(VoteDto voteData)
        {
            var user = _Data.isValidAPIKey(Request.Headers["ApiKey"]);
            if (user is null) { return Unauthorized("\"ApiKey\" has no value or invalid"); }

            Vote vote = new Vote()
            {
                Id = "V_"+Guid.NewGuid().GetHashCode(),
                AuthorId = user.Id,
                ThingId = voteData.thingId,
                vote = voteData.rating
            };
            _Data.Vote(vote);
            return Ok("Voted");
        }


        // GET ###/api/posts/comment###
        //Looks through all Posts
        [HttpGet]
        [Route("comments")]
        public ActionResult<IEnumerable<CommentDto>> GetComments([FromBody]string Id)
        {
            //var post = _Data.getPost(Id);
            //if (post is null) { return NotFound($"The post with the Id of: {Id} was not found"); }

            var comments = _Data.getComments(Id);
            return comments.Select(comment => comment.AsDto(_Data.getVotes(Id))).ToList();
        }


        // Post ###/api/posts/comment###
        //Adds a comment
        [HttpPost]
        [Route("comments")]
        public ActionResult CommentPost(CUCommentDto commentdata)
        {

            var user = _Data.isValidAPIKey(Request.Headers["ApiKey"]);
            if (user is null) { return Unauthorized("\"ApiKey\" has no value or invalid"); }

            var post = _Data.getPost(commentdata.PostId);
            if (post is null) { return NotFound($"The post with the Id of: {commentdata.PostId} was not found"); }



            var comment = new Comment()
            {
                Id = "C_"+Guid.NewGuid().GetHashCode(),
                PostId = commentdata.PostId,
                AuthorId = user.Id,
                Content = commentdata.Content,
                CommentDate = DateTime.Now
            };

            _Data.addComment(comment);



            return Ok("Created Comment");
        }


        [HttpPut]
        [Route("comments/{Id}")]
        public ActionResult<CommentDto> UpdateComment(string Id, CUCommentDto commentdata)
        {


            var exComment = _Data.getComment(Id);
            if (exComment is null) { return NotFound($"The Comment with the Id of: {Id} was not found"); }

            var user = _Data.isValidAPIKey(Request.Headers["ApiKey"]);
            if (user.Id != exComment.AuthorId) { return Unauthorized("\"ApiKey\" has no value or invalid"); }



            _Data.updateComment(Id, commentdata);

            return Ok("Edit Successfull");
        }



    }
}
