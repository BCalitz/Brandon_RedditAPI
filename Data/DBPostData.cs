using Brandon_RedditAPI.Dtos;
using Brandon_RedditAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace Brandon_RedditAPI.Data
{
    public class DBPostData : IPostData
    {
        private readonly DBSetup _context;

        public DBPostData(DBSetup context)
        {
            _context = context;
        }

        public void addComment(Comment comment)
        {
            _context.comments.Add(comment);
            _context.SaveChanges();
        }

        public void addPost(Post post)
        {
            _context.posts.Add(post);
            _context.SaveChanges();
        }

        public void deletePost(string Id)
        {
            _context.posts.Remove(getPost(Id));
            _context.SaveChanges();
        }

        public Comment getComment(string Id)
        {
            return _context.comments.Single(c => c.Id == Id);
        }

        public IEnumerable<Comment> getComments(string Id)
        {
            return _context.comments.Where(c => c.PostId == Id);
        }

        public Post getPost(string Id)
        {
            return _context.posts.SingleOrDefault(p => p.Id == Id);
        }

        public IEnumerable<Post> getPosts()
        {
            return _context.posts.ToList();
        }

        public void updatePost(string Id, CUPostDto postdata)
        {
           var post =  getPost(Id);
            //only changing data that has been inserted
            if (!(postdata.Title is null)) { post.Title = postdata.Title; }
            if (!(postdata.Tags is null)) { post.Tags = postdata.Tags; }
            if (!(postdata.Content is null)) { post.Content = postdata.Content; }
            _context.SaveChanges();
        }


        public void updateComment(CommentDto commentdata)
        {
            var comment = getComment(commentdata.Id);
            if (!(commentdata.Content is null)) { comment.Content = commentdata.Content; }
            _context.SaveChanges();
            }

        public void Vote(Vote vote)
        {
            _context.votes.Add(vote);
            _context.SaveChanges();
        }

        public void AddUser(User user)
        {
            _context.users.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<Post> getUserPosts(string AuthorId)
        {
            return _context.posts.Where(p => p.AuthorId == AuthorId).ToList();
        }

        public IEnumerable<Post> getUserActivity(string AuthorId)
        {
            var activitys =  _context.votes.Where(p => p.AuthorId == AuthorId).ToList();
            List<Post> posts = new List<Post>();
            foreach(var activity in activitys)
            {
                if (activity.ThingId[0] == 'P')
                {
                    posts.Add(getPost(activity.ThingId));
                }
            }
            return posts;
        }

        public User getUser(string Id)
        {
            return _context.users.SingleOrDefault(u => u.Id == Id);
        }
    }
}
