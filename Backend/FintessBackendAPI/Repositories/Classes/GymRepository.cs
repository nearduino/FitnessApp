using FintessBackendAPI.Data;
using FintessBackendAPI.Models;

namespace FintessBackendAPI.Repositories.Classes
{
    public class GymRepository : IGymRepository
    {
        public GymRepository()
        {
            var context = new FitnessAppDbContext();
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
            context.Gyms.AddRange(gyms);
            context.SaveChanges();
        }

        public List<Gym> GetGyms()
        {
            using var context = new FitnessAppDbContext();
            var list = context.Gyms.ToList();
            return list;
        }
    }
}
