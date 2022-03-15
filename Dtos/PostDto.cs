using System;

namespace PosterrAPI.Dtos
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
    }
}
