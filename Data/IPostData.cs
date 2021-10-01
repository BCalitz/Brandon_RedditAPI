using Brandon_RedditAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brandon_RedditAPI.Data
{
    public interface IPostData
    {
        void addPost(Post post);
        Post getPost(Guid id);
        IEnumerable<Post> getPosts();

        void updatePost(Post post);

        void deletePost(Guid id);
        //void upVote(Guid id);
        //void downVote(Guid id);
        void addComment(Comment comment);
        IEnumerable<Comment> getComments(Guid Id);
        Comment getComment(Guid Id);
    }
}
