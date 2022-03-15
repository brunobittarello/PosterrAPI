using System;

namespace PosterrAPI.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public DateTime JoinedAt { get; set; }
    }
}
