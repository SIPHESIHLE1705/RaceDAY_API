
using System.Text.Json.Serialization;

namespace RaceDAY_API.Models
{
    public class User
    {
        public int userID { get; set; }
        public string fullName { get; set; } = string.Empty;
        public string emailAddress { get; set; } = string.Empty;

        [JsonIgnore]
        public string password { get; set; } = string.Empty;

        public string userRole { get; set; } = string.Empty;
    }
}