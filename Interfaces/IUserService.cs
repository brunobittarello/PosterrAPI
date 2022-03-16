using System;
using System.Collections.Generic;
using PosterrAPI.Entities;
using PosterrAPI.Services;

namespace PosterrAPI.Interfaces
{
    public interface IUserService
    {
        public User GetCurrentUser();
        public IEnumerable<Follow> GetAllFollowers();
        public IEnumerable<Follow> GetFollowers(int page);
        public bool AddFollow(Guid userId);
        public bool RemoveFollow(Guid userId);
    }
}