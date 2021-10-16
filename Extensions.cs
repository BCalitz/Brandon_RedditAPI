﻿using Brandon_RedditAPI.Dtos;
using Brandon_RedditAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brandon_RedditAPI
{
    public static class Extensions
    {

        public static PostDto AsDto(this Post post,Votes votes)
        {
            return new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.AuthorId,
                Content = post.Content,
                Tags = post.Tags,
                votes = votes,
                PostDate = post.PostDate
            };
        }

        public static CommentDto AsDto(this Comment comment,Votes votes)
        {
            return new CommentDto
            {
                Id = comment.Id,
                PostId = comment.PostId,
                AuthorId = comment.AuthorId,
                Content = comment.Content,
                votes = votes,
                PostDate = comment.CommentDate
            };
        }

        public static PostDto AsDto(this Post post, IEnumerable<CommentDto> comments, Votes votes)
        {
            return new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                AuthorId = post.AuthorId,
                Tags = post.Tags,
                votes = votes,
                PostDate = post.PostDate,
                comments = comments,
        };
        }


    }
}
