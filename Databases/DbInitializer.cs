using System;
using System.Linq;
using PosterrAPI.Databases;
using PosterrAPI.Entities;

namespace PosterrAPI.Databases
{
    public static class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = Enumerable.Range(1, 20).Select(index => FakeUser());
            context.Users.AddRange(users);

            var random = new Random();
            var userTotal = users.Count();
            var posts = Enumerable.Range(1, 300).Select(index => FakeMessage(users.ElementAt(random.Next(0, userTotal))));
            context.Posts.AddRange(posts);

            var mainUser = users.ElementAt(0);
            var follow = Enumerable.Range(1, 10).Select(index => new Follow() { User = mainUser, UserFollowed = users.ElementAt(index), AddedAt = DateTime.Now });

            context.SaveChanges();
        }

        private static User FakeUser()
        {
            return new User()
            {
                //Id = Guid.NewGuid(),
                UserName = Faker.Name.First(),
                JoinedAt = DateTime.Now
            };
        }

        private static Post FakeMessage(User user)
        {
            return new Post()
            {
                Text = Faker.Lorem.Sentence(10),
                CreatedAt = DateTime.Now,
                User = user
            };
        }
    }
}