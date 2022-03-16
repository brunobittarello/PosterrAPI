using System;
using System.Collections.Generic;
using PosterrAPI.Dtos;
using PosterrAPI.Services;

namespace PosterrAPI.Interfaces
{
    public interface IPostService
    {
        public IEnumerable<PostDto> GetPosts(int page, TimelineSubject subject);
        public bool CreatePost(string text);
        public bool CreateQuote(Guid targetId, string text);
        public bool CreateRepost(Guid targetId);
    }
}