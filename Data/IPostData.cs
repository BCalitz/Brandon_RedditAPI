using Brandon_RedditAPI.Dtos;
using Brandon_RedditAPI.Models;
using System.Collections.Generic;

namespace Brandon_RedditAPI.Data
{
    public interface IPostData
    {
        void addPost(Post post);
        public Post getPost(string id);
        IEnumerable<Post> getPosts();
        void updatePost(string Id, CUPostDto postdata);
        void deletePost(string id);
        void addComment(Comment comment);
        IEnumerable<Comment> getComments(string Id);
        Comment getComment(string Id);
        public void updateComment(string Id, CUCommentDto commentdata);
        void Vote(Vote vote);
        void AddUser(User user);

        User getUser(string Id);
        IEnumerable<Post> getUserActivity(string AuthorId);
        IEnumerable<Post> getUserPosts(string AuthorId);
        User login(LoginDto loginInfo);
        User isValidAPIKey(string APIKey);
        Votes getVotes(string Id);
    }
}
