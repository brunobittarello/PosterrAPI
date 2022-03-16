using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using PosterrAPI.Databases;
using PosterrAPI.Entities;
using PosterrAPI.Services;
using Xunit;

namespace PosterrAPI.Tests
{
    public class PostServiceTests
    {
        [Fact]
        public void ShouldReturnAllPosts()
        {
            // Given
            var mockPosts = Enumerable.Range(1, 5).Select(i => new Post());
            var context = SetupMockDatabase(mockPosts);

            // When
            var service = new PostService(context, new Mock<UserService>().Object);
            var posts = service.GetPosts(1, TimelineSubject.All);

            // Then
            posts.Should().NotBeEmpty().And.HaveCount(mockPosts.Count());
        }

        private DataContext SetupMockDatabase(IEnumerable<Post> posts)
        {
            var context = new Mock<DataContext>();
            var query = posts.AsQueryable();
            var dbSet = new Mock<DbSet<Follow>>();
            dbSet.As<IQueryable<Follow>>().Setup(m => m.Provider).Returns(query.Provider);
            context.Setup(c => c.Followes).Returns(dbSet.Object);
            return context.Object;
        }
    }
}
