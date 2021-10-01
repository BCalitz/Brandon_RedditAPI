using Brandon_RedditAPI.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brandon_RedditAPI.Data
{
    public class DBPostData : IPostData
    {
        private const string _dbName = "brandonReddit";
        private const string _postCollName = "posts";
        private const string _commentCollName = "comments";

        private readonly IMongoCollection<Post> postColl;
        private readonly IMongoCollection<Comment> commentColl;
        public DBPostData(IMongoClient mongoClient)
        {
            IMongoDatabase db = mongoClient.GetDatabase(_dbName);

            postColl = db.GetCollection<Post>(_postCollName);
            commentColl = db.GetCollection<Comment>(_commentCollName);
        }

        public void addComment(Comment comment)
        {
            commentColl.InsertOne(comment);
        }

        public void addPost(Post post)
        {
            postColl.InsertOne(post);
        }

        public void deletePost(Guid id)
        {
            postColl.DeleteOne(post => post.Id == id);
        }

        public Comment getComment(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> getComments(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Post getPost(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> getPosts()
        {
            throw new NotImplementedException();
        }

        public void updatePost(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
