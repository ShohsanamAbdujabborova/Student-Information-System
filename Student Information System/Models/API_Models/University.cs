using Newtonsoft.Json;
namespace Student_Information_System.Models.API_Models;

public class University
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("address")]
    public string Address { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }
}
