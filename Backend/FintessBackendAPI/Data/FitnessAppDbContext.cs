using FintessBackendAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FintessBackendAPI.Data
{
    public class FitnessAppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("FitnessAppDb");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Gym> Gyms { get; set; }
    }
}
