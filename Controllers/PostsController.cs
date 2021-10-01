using Brandon_RedditAPI.Data;
using Brandon_RedditAPI.Dtos;
using Brandon_RedditAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brandon_RedditAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private IPostData _Data;
        public PostsController(IPostData postData)
        {
            this._Data = postData;
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
        public ActionResult<PostDto> GetPost(Guid Id)
        {
            var post = _Data.getPost(Id);
            if(post is null) { NotFound($"The post with the Id of: {Id} was not found"); }

            return post.AsDto();
        }

        // POST ###/api/posts/###
        //Create a post
        [HttpPost]
        [Route("")]
        public ActionResult<PostDto> AddPost(PostDto postdata)
        {
            Post post = new Post()
            {
                Id = Guid.NewGuid(),
                AuthorId = Guid.Empty,
                Title = postdata.Title,
                Content = postdata.Content,
                Tags = postdata.Tags,
                Downvotes = 0,
                Upvotes = 0,
                PostDate = DateTime.Now

            };

            _Data.addPost(post);

            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post.AsDto());
        }


        // PUT ###/api/posts/{Id}###
        //Edits the Post
        [HttpPut]
        [Route("{Id}")]
        public ActionResult<PostDto> UpdatePost(Guid Id, PostDto postdata)
        {
            var exPost = _Data.getPost(Id);
            if (exPost is null)
            {
                return NotFound();
            }

            Post post = exPost;
            //only changing data that has been inserted
            if (!(postdata.Title is null)) { post.Title = postdata.Title; }
            if (!(postdata.Tags is null)) { post.Tags = postdata.Tags; }
            if (!(postdata.Content is null)) { post.Content = postdata.Content; }

            _Data.updatePost(post);

            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post.AsDto());
        }

        // DELETE ###/api/posts/{Id}###
        //Edits the Post
        [HttpDelete]
        [Route("{Id}")]
        public ActionResult DeletePost(Guid Id)
        {
            var exPost = _Data.getPost(Id);
            if (exPost is null)
            {
                return NotFound();
            }

            _Data.deletePost(Id);
            return NoContent();
        }

        // Post ###/api/posts/vote###
        //Edits the Post
        [HttpPost]
        [Route("vote")]
        public ActionResult VotePost(VoteDto vote)
        {
            var exPost = _Data.getPost(vote.thingId);
            if (exPost is null)
            {
                return NotFound();
            }

            

            if(vote.rating == -1) { _Data.downVote(vote.thingId); }
            else if(vote.rating == 1) { _Data.upVote(vote.thingId); }

            return Ok("Voted");
        }


        // GET ###/api/posts/comment###
        //Looks through all Posts
        [HttpGet]
        [Route("comments")]
        public ActionResult<IEnumerable<CommentDto>> GetComments([FromBody]Guid Id)
        {
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
            if (post is null)
            {
                return NotFound();
            }

            var comment = new Comment()
            {
                Id = Guid.NewGuid(),
                PostId = commentdata.PostId,
                AuthorId = Guid.Empty,
                Content = commentdata.Content,
                Upvotes = 0,
                Downvotes = 0,
                CommentDate = DateTime.Now
            };

            _Data.addComment(comment);



            return Ok("Created Comment");
        }



    }
}
