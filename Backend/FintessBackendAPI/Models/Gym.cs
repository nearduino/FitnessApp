namespace FintessBackendAPI.Models
{
    public class Gym
    {
        public int Id { get; set; }

        public string Brand { get; set; }
        public int Since { get; set; }
        User Owner { get; set; }

    }
}
