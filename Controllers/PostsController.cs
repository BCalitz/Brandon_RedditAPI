﻿using Brandon_RedditAPI.Data;
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
            var posts = _Data.getPosts().Select(post => post.AsDto());
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

            return post.AsDto(_Data.getComments(Id));
        }

        // POST ###/api/posts/###
        //Create a post
        [HttpPost]
        [Route("")]
        public ActionResult<PostDto> AddPost(PostDto postdata)
        {
            Post post = new Post()
            {
                Id = "P_"+Guid.NewGuid().GetHashCode(),
                AuthorId = postdata.AuthorId,
                Title = postdata.Title,
                Content = postdata.Content,
                Tags = postdata.Tags,
                Downvotes = 0,
                Upvotes = 0,
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
            if (_Data.getPost(Id) is null) { return NotFound($"The post with the Id of: {Id} was not found"); }

            

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

            _Data.deletePost(Id);
            return Ok("Deleted Post");
        }

        // Post ###/api/posts/vote###
        //Edits the Post
        [HttpPost]
        [Route("vote")]
        public ActionResult VotePost(VoteDto voteData)
        {
            Vote vote = new Vote()
            {
                Id = "V_"+Guid.NewGuid().GetHashCode(),
                AuthorId = null,
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
            return comments.Select(comment => comment.AsDto()).ToList();
        }


        // Post ###/api/posts/comment###
        //Adds a comment
        [HttpPost]
        [Route("comments")]
        public ActionResult CommentPost(CUCommentDto commentdata)
        {
            var post = _Data.getPost(commentdata.PostId);
            if (post is null) { return NotFound($"The post with the Id of: {commentdata.PostId} was not found"); }

            var comment = new Comment()
            {
                Id = "C_"+Guid.NewGuid().GetHashCode(),
                PostId = commentdata.PostId,
                AuthorId = commentdata.AuthorId,
                Content = commentdata.Content,
                Upvotes = 0,
                Downvotes = 0,
                CommentDate = DateTime.Now
            };

            _Data.addComment(comment);



            return Ok("Created Comment");
        }


        [HttpPut]
        [Route("comment/{Id}")]
        public ActionResult<CommentDto> UpdateComment(string Id, CommentDto commentdata)
        {
            var exComment = _Data.getComment(Id);
            if (exComment is null) { return NotFound($"The Comment with the Id of: {Id} was not found"); }

    
            

            _Data.updateComment(commentdata);

            return Ok("Edit Successfull");
        }



    }
}
