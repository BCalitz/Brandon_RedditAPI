using Brandon_RedditAPI.Dtos;
using Brandon_RedditAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brandon_RedditAPI.Data
{
    public interface IPostData
    {
        void addPost(Post post);
        public Post getPost(string id);
        IEnumerable<Post> getPosts();
        void updatePost(PostDto postdata);
        void deletePost(string id);
        void addComment(Comment comment);
        IEnumerable<Comment> getComments(string Id);
        Comment getComment(string Id);
        void updateComment(CommentDto commentdata);
        void Vote(Vote vote);
        void AddUser(User user);
        IEnumerable<Post> getUserActivity(string AuthorId);
        IEnumerable<Post> getUserPosts(string AuthorId);
    }
}
