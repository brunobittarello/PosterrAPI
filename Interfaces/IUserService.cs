using PosterrAPI.Entities;

namespace PosterrAPI.Interfaces
{
    public interface IUserService
    {
        public User GetCurrentUser();
    }
}