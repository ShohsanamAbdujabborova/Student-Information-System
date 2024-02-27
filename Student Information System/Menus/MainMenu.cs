using Spectre.Console;
using Student_Information_System.Menus.SubMenu;
using Student_Information_System.Models.API_Models;
using Student_Information_System.Services.API_Service;
using Student_Information_System.Services.StudentService;
namespace Student_Information_System.Menus;
public class MainMenu
{
#pragma warning disable
    private MajorsAPI majorsAPI;
    private StudentModelService studentService;
    private readonly StudentMenu studentMenu;

    public MainMenu()
    {
        majorsAPI = new MajorsAPI();
        try
        {
            majorsAPI.GetDataAsync().Wait();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to get data from the API!");
            Task.Delay(3000);
            throw new Exception($"{ex.Message}");
        }

        studentService = new StudentModelService();
        studentMenu = new StudentMenu(studentService);
    }

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            AnsiConsole.WriteLine("Student Information System\n");
            AnsiConsole.WriteLine("Main Menu");
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .PageSize(5)
                    .AddChoices(new[] { "Student Menu", "Majors\n", "Exit" }));

            switch (choice)
            {
                case "Student Menu":
                    studentMenu.Run();
                    break;
                case "Majors\n":
                    List<Major> majorslist = majorsAPI.GetMajors();
                    foreach (Major m in majorslist)
                    {
                        Console.WriteLine($"Id: {m.ID}");
                        Console.WriteLine($"Name: {m.Name}");
                        Console.WriteLine($"Description: {m.Description}");
                        Console.WriteLine($"Subjects: ");
                        foreach (var s in m.SubjectDescription) Console.WriteLine("    " + s);
                        Console.WriteLine($"University: ");
                        Console.WriteLine($"    University Name: {m.University.Name}");
                        Console.WriteLine($"    University Address: {m.University.Address}");
                        Console.WriteLine($"    University Country: {m.University.Country}\n\n\n");
                    }
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadLine();
                    break;
                case "Exit":
                    AnsiConsole.WriteLine("Exiting the application.");
                    return;
                default:
                    AnsiConsole.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }

        }
    }
}

