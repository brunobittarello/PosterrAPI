using System;

namespace PosterrAPI.Entities
{
    public class Follow
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid UserFollowedId { get; set; }
        public DateTime AddedAt { get; set; }

        public virtual User User { get; set; }
        public virtual User UserFollowed { get; set; }
    }
}
