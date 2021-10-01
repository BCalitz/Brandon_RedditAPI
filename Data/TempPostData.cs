using Brandon_RedditAPI.Controllers;
using Brandon_RedditAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brandon_RedditAPI.Data
{
    public class TempPostData : IPostData
    {
        private List<Post> posts = new List<Post>()
        {
                new Post {Id = Guid.NewGuid(), AuthorId = Guid.Empty, Content = "This is a test", Title= "Test", PostDate = DateTime.Now},
                new Post {Id = Guid.NewGuid(), AuthorId = Guid.Empty, Content = "Hello", Title= "Hello", PostDate = DateTime.Now}
        };

        private List<Comment> comments = new List<Comment>() { };

        public void addPost(Post post)
        {
            posts.Add(post);
        }

        public void deletePost(Guid id)
        {
            posts.RemoveAt(posts.FindIndex(post => post.Id == id));
        }


        public Post getPost(Guid id)
        {
            return posts.Where(post => post.Id == id).SingleOrDefault();
        }

        public IEnumerable<Post> getPosts()
        {
            return posts;
        }

        public void updatePost(Post post)
        {
            var index = posts.FindIndex(existingPost => existingPost.Id == post.Id);
            posts[index] = post;
        }


        public IEnumerable<Comment> getComments(Guid Id)
        {
            return comments.FindAll(comment => comment.PostId == Id);
        }

        public Comment getComment(Guid Id)
        {
            return comments.Where(comment => comment.Id == Id).SingleOrDefault();
        }

        public void addComment(Comment comment)
        {
            comments.Add(comment);
        }

        
    }
}