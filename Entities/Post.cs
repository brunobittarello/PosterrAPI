using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PosterrAPI.Entities
{
    public class Post
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Text { get; set; }
        public Guid? QuoteId { get; set; }
        public Guid? RepostId { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual User User { get; set; }
        [ForeignKey("QuoteId")]
        public virtual Post Quote { get; set; }
        [ForeignKey("RepostId")]
        public virtual Post Repost { get; set; }
    }
}
