using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PosterrAPI.Databases;
using PosterrAPI.Dtos;
using PosterrAPI.Entities;
using PosterrAPI.Interfaces;

namespace PosterrAPI.Services
{
    public enum TimelineSubject
    {
        All, Followers, User
    }

    public class PostService : IPostService
    {
        const int PAGE_SIZE = 10;
        private readonly DataContext _dbContext;
        private readonly IUserService _userService;

        public PostService(DataContext dbContext, IUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        public IEnumerable<PostDto> GetPosts(int page, TimelineSubject subject)
        {
            var posts = GetPostsFromSubject(subject)            
                .OrderByDescending(p => p.CreatedAt)
                .Skip(page * PAGE_SIZE)
                .Take(PAGE_SIZE).ToList();
            return posts.Select(m => PostToDto(m));
        }

        public bool CreatePost(string text)
        {
            var user = _userService.GetCurrentUser();
            if (user == null)
                return false;

            if (!ValidText(text))
                return false;

            var post = new Post()
            {
                UserId = user.Id,
                Text = text,
                CreatedAt = DateTime.Now,
            };

            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();

            return true;
        }

        public bool CreateQuote(Guid targetId, string text)
        {
            var user = _userService.GetCurrentUser();
            if (user == null)
                return false;

            var target = _dbContext.Posts.SingleOrDefault(p => p.Id == targetId);
            if (target == null)
                return false;

            if (!ValidText(text))
                return false;

            var post = new Post()
            {
                UserId = user.Id,
                Text = text,
                QuoteId = target.Id,
                CreatedAt = DateTime.Now,
            };

            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();

            return true;
        }

        public bool CreateRepost(Guid targetId)
        {
            var user = _userService.GetCurrentUser();
            if (user == null)
                return false;

            var target = _dbContext.Posts.SingleOrDefault(p => p.Id == targetId);
            if (target == null)
                return false;

            var post = new Post()
            {
                UserId = user.Id,
                RepostId = target.Id,
                CreatedAt = DateTime.Now,
            };

            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();

            return true;
        }

        private IEnumerable<Post> GetPostsFromSubject(TimelineSubject subject)
        {
            switch (subject)
            {
                case TimelineSubject.All: return GetPostsFromAll();
                case TimelineSubject.Followers: return GetPostsFromFollowers();
                case TimelineSubject.User: return GetPostsFromUser();
            }
            return null;
        }

        private IEnumerable<Post> GetPostsFromAll()
        {
            return _dbContext.Posts.Include("User");
        }

        private IEnumerable<Post> GetPostsFromFollowers()
        {
            var followers = new List<Guid>();
            return _dbContext.Posts.Include("User").Where(p => followers.Contains(p.UserId));
        }

        private IEnumerable<Post> GetPostsFromUser()
        {
            var user = _userService.GetCurrentUser();
            return _dbContext.Posts.Include("User").Where(p => p.UserId == user.Id);
        }

        private bool ValidText(string text)
        {
            return text.Length <= 777;
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
