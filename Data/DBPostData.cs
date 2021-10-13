using Brandon_RedditAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brandon_RedditAPI.Data
{
    public class DBPostData : IPostData
    {
        private readonly IMongoCollection<Post> postColl;
        private readonly IMongoCollection<Comment> commentColl;
        private readonly IMongoCollection<User> userColl;

        private readonly FilterDefinitionBuilder<Post> postFilterBuilder = Builders<Post>.Filter;
        private readonly FilterDefinitionBuilder<Comment> commentFilterBuilder = Builders<Comment>.Filter;

        public DBPostData(IMongoClient mongoClient)
        {
            IMongoDatabase db = mongoClient.GetDatabase("brandonReddit");

            postColl = db.GetCollection<Post>("posts");
            commentColl = db.GetCollection<Comment>("comments");
            userColl = db.GetCollection<User>("users");
        }

        public void addComment(Comment comment)
        {
            commentColl.InsertOne(comment);
        }

        public void addPost(Post post)
        {
            postColl.InsertOne(post);
        }

        public void deletePost(string id)
        {
            var filter = postFilterBuilder.Eq(post => post.Id, id);
            postColl.DeleteOne(filter);
        }

        public Comment getComment(string Id)
        {
            var filter = commentFilterBuilder.Eq(comment => comment.Id, Id);
            return commentColl.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Comment> getComments(string Id)
        {
            var filter = commentFilterBuilder.Eq(comment=> comment.PostId, Id);
            return commentColl.Find(filter).ToList();
        }

        public Post getPost(string id)
        {
            var filter = postFilterBuilder.Eq(post => post.Id, id);
            return postColl.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Post> getPosts()
        {
            return postColl.Find(new BsonDocument()).ToList();
        }

        public void updatePost(Post post)
        {
            var filter = postFilterBuilder.Eq(expost => expost.Id, post.Id);
            postColl.ReplaceOne(filter, post);
        }


        public void updateComment(Comment comment)
        {
            var filter = commentFilterBuilder.Eq(expost => expost.Id, comment.Id);
            commentColl.ReplaceOne(filter, comment);
        }

        public void Vote<T>(T thing)
        {
            if (thing is Post) 
            {
                updatePost((Post)(object)thing);
            }else if(thing is Comment)
            {
                updateComment((Comment)(object)thing);
            }
        }

        public void AddUser(User user)
        {
            userColl.InsertOne(user);
        }

        public IEnumerable<Post> getUserPosts(string AuthorId)
        {
            var filter = postFilterBuilder.Eq(post => post.AuthorId, AuthorId);
            return postColl.Find(filter).ToList();
        }

        public IEnumerable<Post> getUserActivity(string AuthorId)
        {
            var filter = postFilterBuilder.Eq(post => post.AuthorId, AuthorId);
            return postColl.Find(filter).ToList();
        }



    }
}
