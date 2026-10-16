
using System.Text.Json.Serialization;

namespace RaceDAY_API.Models
{//satrt of namespace
    public class User
    {//start of class
        public int userID { get; set; }
        public string fullName { get; set; } = string.Empty;
        public string emailAddress { get; set; } = string.Empty;

        [JsonIgnore]
        public string password { get; set; } = string.Empty;

        public string userRole { get; set; } = string.Empty;
    }//end of class
}//end of namesapce
