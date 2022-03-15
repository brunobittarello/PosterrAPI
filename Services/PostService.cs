using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PosterrAPI.Databases;
using PosterrAPI.Dtos;
using PosterrAPI.Entities;
using PosterrAPI.Interfaces;

namespace PosterrAPI.Services
{
    public class PostService : IPostService
    {
        private readonly DataContext _dbContext;

        public PostService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<PostDto> GetPosts(int page)
        {
            var posts = _dbContext.Posts.Include("User").ToList();
            return posts.Select(m => PostToDto(m));
        }

        private PostDto PostToDto(Post post)
        {
            return new PostDto()
            {
                Id = post.Id,
                Text = post.Text,
                UserName = post.User.UserName
            };
        }
    }
}
