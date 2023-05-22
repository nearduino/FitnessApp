using FintessBackendAPI.Models;

namespace FintessBackendAPI.Data;

public static class DatabaseInitializer
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = serviceProvider.GetRequiredService<FitnessAppDbContext>();

        // Check if the database already exists
        if (context.Database.EnsureCreated())
        {
            // Seed the database with default users
            var users = new List<User>
            {
                new User
                {
                    Username = "Arnold",
                    Password = "germany123"
                },
                new User
                {
                    Username = "Michelle",
                    Password = "WhiteHouseEnjoyer"
                }
            };

            var gyms = new List<Gym>
            {
                new Gym
                {
                    Brand = "Gold's Gym",
                    Since = 1965
                },
                new Gym
                {
                    Brand = "24 Hour Fitness",
                    Since = 1983
                }
            };

            context.Users.AddRange(users);
            context.Gyms.AddRange(gyms);
            context.SaveChanges();
        }
    }
}
