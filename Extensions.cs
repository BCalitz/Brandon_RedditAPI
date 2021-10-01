using Brandon_RedditAPI.Dtos;
using Brandon_RedditAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brandon_RedditAPI
{
    public static class Extensions
    {

        public static PostDto AsConDto(this Post post)
        {
            return new PostDto
            {
                Id = post.Id,
                AuthorId = post.AuthorId,
                Title = post.Title,
                Content = post.Content,
                Tags = post.Tags,
                Downvotes = post.Downvotes,
                Upvotes = post.Upvotes,
                PostDate = post.PostDate
            };
        }

        public static PostDto AsDto(this Post post)
        {
            return new PostDto
            {
                Id = post.Id,
                AuthorId = post.AuthorId,
                Title = post.Title,
                Content = post.Content,
                Tags = post.Tags,
                Downvotes = post.Downvotes,
                Upvotes = post.Upvotes,
                PostDate = post.PostDate,
                Comments = post.Comments
            };
        }


    }
}
