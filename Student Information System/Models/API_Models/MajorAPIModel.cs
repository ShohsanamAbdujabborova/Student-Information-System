using System.Collections.Generic;
using Newtonsoft.Json;

namespace Student_Information_System.Models.API_Models
{
    public class Major
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("university")]
        public University University { get; set; }

        [JsonProperty("subjects")]
        public List<string> SubjectDescription { get; set; }
    }
}
