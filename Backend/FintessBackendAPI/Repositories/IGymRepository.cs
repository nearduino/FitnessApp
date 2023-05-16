using FintessBackendAPI.Models;

namespace FintessBackendAPI.Repositories
{
    public interface IGymRepository
    {
        public List<Gym> GetGyms();
    }
}
