using Newtonsoft.Json;
using Student_Information_System.Models.Commons;

namespace Student_Information_System.Models.Student_Models;
public class StudentModel : Auditable
{
    [JsonProperty("studentId")]
    public string StudentId { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("surname")]
    public string SurName { get; set; }
    [JsonProperty("email")]
    public string Email { get; set; }
    [JsonProperty("birthOfDate")]
    public DateOnly BirthOfDate { get; set; }
    [JsonProperty("phoneNumber")]
    public string PhoneNumber { get; set; }
    [JsonProperty("parentsPhoneNumber")]
    public string Parents_PhoneNumber { get; set; }
    [JsonProperty("majors")]
    public string Majors { get; set; }
    [JsonProperty("subjects")]
    public List<string> Subjects { get; set; } = new List<string>();
    [JsonProperty("nation")]
    public string Nation { get; set; }
    [JsonProperty("gender")]
    public string Gender { get; set; }
    [JsonProperty("teachersType")]
    public string TeachersType { get; set; }
}
