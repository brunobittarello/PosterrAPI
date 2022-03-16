using System;
using System.Collections.Generic;
using System.Linq;
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
            context.SaveChanges();

            users = context.Users.ToList();
            var random = new Random();
            var posts = new List<Post>();
            foreach (var user in users) {
                posts.AddRange(Enumerable.Range(1, random.Next(10, 20)).Select(index => FakeMessage(user)));
            }
            context.Posts.AddRange(posts);

            var mainUser = context.Users.First();
            mainUser.UserName = "Bruno";
            context.Users.Update(mainUser);
            var followers = Enumerable.Range(1, 10).Select(index => new Follow() { User = mainUser, UserFollowed = users.ElementAt(index), AddedAt = DateTime.Now });
            context.Followes.AddRange(followers);

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