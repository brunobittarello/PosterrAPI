using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PosterrAPI.Databases;
using PosterrAPI.Dtos;
using PosterrAPI.Entities;
using PosterrAPI.Interfaces;

namespace PosterrAPI.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _dbContext;

        public UserService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetCurrentUser() => _dbContext.Users.First();
    }
}
