using FintessBackendAPI.Data;
using FintessBackendAPI.Models;

namespace FintessBackendAPI.Repositories.Classes
{
    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {
            var context = new FitnessAppDbContext();
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
            context.Users.AddRange(users);
            context.SaveChanges();
        }

        public List<User> GetUsers()
        {
            using var context = new FitnessAppDbContext();
            var list = context.Users.ToList();
            return list;
        }
    }
}
