using Newtonsoft.Json;
using Spectre.Console;
using Student_Information_System.Models.API_Models;
namespace Student_Information_System.Services.API_Service;
public class MajorsAPI
{

    public const string MAJORS_API_PATH = "https://majorsapi.onrender.com/majors";

    private HttpClient majorsData;

    private List<Major> majorsList;


    public MajorsAPI()
    {
        majorsList = new List<Major>();

        majorsData = new HttpClient();

        majorsData.BaseAddress = new Uri(MAJORS_API_PATH);
    }

    //public async Task GetDataAsync()
    //{


    //    var majorsdataResponse = await majorsData.GetAsync(MAJORS_API_PATH);

    //    var MajorsData = await majorsdataResponse.Content.ReadAsStringAsync();

    //    majorsList = JsonConvert.DeserializeObject<List<Major>>(MajorsData);

    //}

    public async Task GetDataAsync()
    {
        await AnsiConsole.Status()
        .StartAsync("Sending request to the API...", async ctx =>
        {
            ctx.Spinner(Spinner.Known.Star);
            ctx.SpinnerStyle(Style.Parse("green"));

            ctx.Status($"[red]Connecting[/] to the server {MAJORS_API_PATH}...");

            await Task.Delay(3000);

            ctx.Status("[green]Collecting[/] data...");

            var majorsdataResponse = await majorsData.GetAsync(MAJORS_API_PATH);

            if (majorsdataResponse.IsSuccessStatusCode)
            {
                ctx.Status("Data has taken successfully. Congrats!");
                var MajorsData = await majorsdataResponse.Content.ReadAsStringAsync();
                majorsList = JsonConvert.DeserializeObject<List<Major>>(MajorsData);
                await Task.Delay(3000);
            }
        });
    }


    public List<Major> GetMajors()
    {
        return majorsList;
    }
}

