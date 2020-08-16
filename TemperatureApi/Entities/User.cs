using System.Text.Json.Serialization;

namespace TemperatureApi.Entities
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        //[JsonIgnore]
        public string Password { get; set; }
        //public string grant_type { get; set; }
    }
}
