using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PosterrAPI.Databases;
using PosterrAPI.Entities;
using PosterrAPI.Interfaces;

namespace PosterrAPI.Services
{
    public class UserService : IUserService
    {
        const int PAGE_SIZE = 10;
        private readonly DataContext _dbContext;

        public UserService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetCurrentUser() => _dbContext.Users.First();

        public IEnumerable<Follow> GetAllFollowers()
        {
            var user = GetCurrentUser();
            var followers = _dbContext.Followes.Include("UserFollowed").
                Where(f => f.UserId == user.Id);
            return followers;
        }

        public IEnumerable<Follow> GetFollowers(int page)
        {
            return GetAllFollowers().Skip((page - 1) * PAGE_SIZE)
                .Take(PAGE_SIZE)
                .OrderBy(f => f.UserFollowed.UserName)
                .ToList();
        }

        public bool AddFollow(Guid userId)
        {
            var user = GetCurrentUser();
            if (userId == Guid.Empty || user.Id == userId)
                return false;

            var follow = _dbContext.Followes.SingleOrDefault(f => f.UserId == user.Id && f.UserFollowedId == userId);
            if (follow != null)
                return false;

            follow = new Follow() { UserId = user.Id, UserFollowedId = userId, AddedAt = DateTime.Now };
            _dbContext.Followes.Add(follow);
            _dbContext.SaveChanges();
            return true;
        }

        public bool RemoveFollow(Guid userId)
        {
            var user = GetCurrentUser();
            if (userId == Guid.Empty || user.Id == userId)
                return false;

            var follow = _dbContext.Followes.SingleOrDefault(f => f.UserId == user.Id && f.UserFollowedId == userId);
            if (follow == null)
                return false;

            _dbContext.Followes.Remove(follow);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
