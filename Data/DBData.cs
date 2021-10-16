using Brandon_RedditAPI.Dtos;
using Brandon_RedditAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace Brandon_RedditAPI.Data
{
    public class DBData : IDBData
    {
        private readonly DBSetup _context;

        public DBData(DBSetup context)
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
            var comment = _context.comments.SingleOrDefault(c => c.Id == Id);
            return comment;

        }

        public IEnumerable<Comment> getComments(string Id)
        {
            var comments =  _context.comments.Where(c => c.PostId == Id);
            return comments;
        }

        public Post getPost(string Id)
        {
            var post =  _context.posts.SingleOrDefault(p => p.Id == Id);
            return post;
        }

        public IEnumerable<Post> getPosts()
        {
            var posts =  _context.posts.ToList();
            return posts;
        }

        public void updatePost(string Id, CUPostDto postdata)
        {
            var post = getPost(Id);
            //only changing data that has been inserted
            if (!(postdata.Title is null)) { post.Title = postdata.Title; }
            if (!(postdata.Tags is null)) { post.Tags = postdata.Tags; }
            if (!(postdata.Content is null)) { post.Content = postdata.Content; }
            _context.SaveChanges();
        }


        public void updateComment(string Id,CUCommentDto commentdata)
        {
            var comment = getComment(Id);
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
            var posts =  _context.posts.Where(p => p.AuthorId == AuthorId).ToList();
            return posts;
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

        public User getUser(string Username)
        {
            return _context.users.SingleOrDefault(u => u.Username == Username);
        }

        public User login(LoginDto loginInfo)
        {
            var user = _context.users.SingleOrDefault(u => u.Username == loginInfo.Username);
            if (user is null) { return null; }
            if (Encoding.UTF8.GetString(user.Password) == loginInfo.Password)
            {
                return user;
            }else { 
                return null; 
            }
        }

        public User isValidAPIKey(string ApiKey)
        {
            try
            {
                var cApi = Guid.Parse(ApiKey);
                var user = _context.users.SingleOrDefault(u => u.APIKey == cApi);
                if (user is null) { return null; }
                return user;
            }
            catch (Exception)
            {

                return null;
            }


        }

        public Votes getVotes(string Id)
        {
            return new Votes()
            {
                UpVotes = _context.votes.Count(v => v.ThingId == Id && v.vote == 1),
                DownVotes = _context.votes.Count(v => v.ThingId == Id && v.vote == -1)
            };
        }

        public User getUserFromId(string Id)
        {
            return _context.users.SingleOrDefault(u => u.Id == Id);
        }
    }
}
