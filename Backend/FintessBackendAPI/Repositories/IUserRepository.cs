using FintessBackendAPI.Models;

namespace FintessBackendAPI.Repositories
{
    public interface IUserRepository
    {
        public List<User> GetUsers();
    }
}
