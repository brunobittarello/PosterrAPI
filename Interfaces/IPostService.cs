using System.Collections.Generic;
using PosterrAPI.Dtos;

namespace PosterrAPI.Interfaces
{
    public interface IPostService
    {
        public IEnumerable<PostDto> GetPosts(int page);
    }
}