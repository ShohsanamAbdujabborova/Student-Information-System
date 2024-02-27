using Spectre.Console;
using Student_Information_System.Enums;
using Student_Information_System.Enums.SubjectEnums;
using Student_Information_System.Models.Student_Models;
using Student_Information_System.Services.StudentService;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
namespace Student_Information_System.Menus.SubMenu;
public class StudentMenu
{
#pragma warning disable
    private readonly StudentModelService studentService;
    public StudentMenu(StudentModelService studentService)
    {
        this.studentService = studentService;
    }
    public void Run()
    {
        while (true)
        {
            AnsiConsole.WriteLine("\nStudent Menu");
            var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .PageSize(7)
            .AddChoices(new[]
            {
                     "Create", "Update", "Delete", "View by id", "Search", "View All", "Exit"
            }));

            switch (choice)
            {
                case "View All":
                    AnsiConsole.Clear();
                    ViewAllStudents();
                    break;
                case "Search":
                    AnsiConsole.Clear();
                    SearchStudents();
                    break;
                case "View by id":
                    AnsiConsole.Clear();
                    ViewStudentsById();
                    break;
                case "Create":
                    AnsiConsole.Clear();
                    Create();
                    break;
                case "Update":
                    AnsiConsole.Clear();
                    Update();
                    break;
                case "Delete":
                    AnsiConsole.Clear();
                    Delete();
                    break;
                case "Exit":
                    AnsiConsole.Clear();
                    AnsiConsole.WriteLine("Exit Student Menu.");
                    return;
                default:
                    AnsiConsole.Clear();
                    AnsiConsole.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }

    private void ViewAllStudents()
    {
        try
        {
            var students = studentService.GetAllAsync().Result.ToList();
            PrintStudentList(students);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private void SearchStudents()
    {
        var searchTerm = AnsiConsole.Ask<string>("Enter search term:");
        try
        {
            var searchResults = studentService.SearchStudentsAsync(searchTerm).Result;
            PrintStudentList(searchResults);
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteLine($"Error: {ex.Message}");
        }
    }
    private static void PrintStudentList(List<StudentViewModel> students)
    {
        Console.WriteLine("Student List:");
        foreach (var student in students)
        {
            PrintStudent(student);
        }
    }

    private void ViewStudentsById()
    {
        var Id = AnsiConsole.Ask<int>("Enter student ID:");
        Console.Write("Enter student ID: ");
        try
        {
            var student = studentService.GetByIdAsync(Id).Result;
            Console.WriteLine("Student Details:");
            PrintStudent(student);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void PrintStudent(StudentViewModel student)
    {
        Console.WriteLine("ID: " + student.Id);
        Console.WriteLine("StudentID: " + student.StudentId);
        Console.WriteLine("Name: " + student.Name);
        Console.WriteLine("SurName: " + student.SurName);
        Console.WriteLine("BirthOfDate: " + student.BirthOfDate.ToString("MM/dd/yyyy"));
        Console.WriteLine("Email: " + student.Email);
        Console.WriteLine("Gender: " + student.Gender);
        Console.WriteLine("Phone Number: " + student.PhoneNumber);
        Console.WriteLine("Parents Phone Number: " + student.Parents_PhoneNumber);
        Console.WriteLine("Majors: " + student.Majors);
        Console.WriteLine("Subjects: ");
        foreach (var s in student.Subjects) {  Console.WriteLine("   "+s); }
        Console.WriteLine("Nation: " + student.Nation);
        Console.WriteLine("TeachersType: " + student.TeachersType);

    }

    private async void Create()
    {
        var studentId = GetValidStudentId("Enter student Id: ");
        var studentName = AnsiConsole.Ask<string>("Enter student name:");
        var studentSurName = AnsiConsole.Ask<string>("Enter student Surname:");
        string email;
        do
        {
            email = AnsiConsole.Ask<string>("Enter email:");
            if (!IsValidEmail(email))
            {
                AnsiConsole.WriteLine("Invalid email format");
            }
        } while (!IsValidEmail(email));
        DateOnly birthOfDate = AnsiConsole.Ask<DateOnly>("Enter birth of date");

        string phoneNumber;
        do
        {
            phoneNumber = AnsiConsole.Ask<string>("Enter student's phone number:");
            if (!IsValidPhoneNumber(phoneNumber))
            {
                AnsiConsole.WriteLine("Invalid phone number format");
            }
        } while (!IsValidPhoneNumber(phoneNumber));

        string parentsPhoneNumber;
        do
        {
            parentsPhoneNumber = AnsiConsole.Ask<string>("Enter parents phone number:");
            if (!IsValidParentsPhoneNumber(parentsPhoneNumber))
            {
                AnsiConsole.WriteLine("Invalid phone number format");
            }
        } while (!IsValidParentsPhoneNumber(parentsPhoneNumber));
reentertypecreate:

        await Console.Out.WriteLineAsync("Choose Majors:");
        await Console.Out.WriteLineAsync("1.Electrical_And_Computer_Engineering");
        await Console.Out.WriteLineAsync("2.Civil_Engineering");
        await Console.Out.WriteLineAsync("3.Architecture");
        await Console.Out.WriteLineAsync("4.English_Philology");
        await Console.Out.WriteLineAsync("5.Korean_Philology");
        string major = Console.ReadLine();
        StudentModel student = new StudentModel();
        switch (major)
        {
            case "1":
                foreach (Civil_Engineering sub in Enum.GetValues(typeof(Electrical_And_Computer_Engineering)))
                {
                    Console.WriteLine(sub);
                    student.Subjects.Add(Convert.ToString(sub));
                }
                student.Majors = Convert.ToString(Majors.Electrical_And_Computer_Engineering);
                break;
            case "2":
                foreach (Civil_Engineering sub in Enum.GetValues(typeof(Civil_Engineering)))
                {
                    Console.WriteLine(sub);
                    student.Subjects.Add(Convert.ToString(sub));
                }
                student.Majors = Convert.ToString(Majors.Civil_Engineering);
                break;
            case "3":
                foreach (Civil_Engineering sub in Enum.GetValues(typeof(Architecture)))
                {
                    Console.WriteLine(sub);
                    student.Subjects.Add(Convert.ToString(sub));
                }

                student.Majors = Convert.ToString(Majors.Architecture);
                break;
            case "4":
                foreach (Civil_Engineering sub in Enum.GetValues(typeof(English_Philology)))
                {
                    Console.WriteLine(sub);
                    student.Subjects.Add(Convert.ToString(sub));
                }
                student.Majors = Convert.ToString(Majors.English_Philology);
                break;
            case "5":
                foreach (Civil_Engineering sub in Enum.GetValues(typeof(Korean_Philology)))
                {
                    Console.WriteLine(sub);
                    student.Subjects.Add(Convert.ToString(sub));
                }
                student.Majors = Convert.ToString(Majors.Korean_Philology);
                break;
            default:
                await Console.Out.WriteLineAsync("wrong choice, Press any key to re-enter");
                goto reentertypecreate;
        }
        var nation = AnsiConsole.Ask<string>("Enter nation:");
reentertypegender:

        await Console.Out.WriteLineAsync("Choose Gender:");
        await Console.Out.WriteLineAsync("1.Male");
        await Console.Out.WriteLineAsync("2.Female");
        string gender = Console.ReadLine();
        switch (gender)
        {
            case "1":
                student.Gender = Convert.ToString(Gender.Male);
                break;
            case "2":
                student.Gender = Convert.ToString(Gender.Female);
                break;
            default:
                await Console.Out.WriteLineAsync("wrong choice, Press any key to re-enter");
                goto reentertypegender;
        }
reentertypeteacher:

        await Console.Out.WriteLineAsync("Choose your teacher by experience:");
        await Console.Out.WriteLineAsync("1.Student must pay tuition fee $3000 for Native teacher");
        await Console.Out.WriteLineAsync("2.Student must pay tuition fee $2500 for Local teacher");
        await Console.Out.WriteLineAsync("3.Student must pay tuition fee $2700 for Native_And_Local_Teachers");
        string teachersType = Console.ReadLine();
        switch (teachersType)
        {
            case "1":
                student.TeachersType = Convert.ToString(TeachersType.Native_Teachers);
                break;
            case "2":
                student.TeachersType = Convert.ToString(TeachersType.Local_Teachers);
                break;
            case "3":
                student.TeachersType = Convert.ToString(TeachersType.Native_And_Local_Teachers);
                break;
            default:
                await Console.Out.WriteLineAsync("wrong choice, Press any key to re-enter");
                goto reentertypeteacher;
        }
        try
        {
            var studentModel = new StudentCreationModel
            {
                StudentId = studentId,
                Name = studentName,
                SurName = studentSurName,
                Email = email,
                Gender = student.Gender,
                Majors = student.Majors,
                Subjects = student.Subjects,
                TeachersType = student.TeachersType,
                PhoneNumber = phoneNumber,
                Parents_PhoneNumber = parentsPhoneNumber,
                Nation = nation,
                BirthOfDate = birthOfDate,
            };
            var createdStudent = studentService.CreateAsync(studentModel).Result;
            await Console.Out.WriteLineAsync($"Student created successfully.Student ID:{createdStudent.Id}");
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync($"Error{ex.Message}");
        }
    }
    private bool IsValidParentsPhoneNumber(string parentsPhoneNumber)
    {
        string parentsPhoneNumberPattern = @"^(\+998|998|0)([1-9]{1}[0-9]{8})$";
        return System.Text.RegularExpressions.Regex.IsMatch(parentsPhoneNumber, parentsPhoneNumberPattern);
    }
    private bool IsValidPhoneNumber(string phoneNumber)
    {
        string phoneNumberPattern = @"^(\+998|998|0)([1-9]{1}[0-9]{8})$";
        return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, phoneNumberPattern);
    }

    private bool IsValidEmail(string email)
    {
        string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        return System.Text.RegularExpressions.Regex.IsMatch(email, emailPattern);
    }

    private async void Update()
    {
        var Id = AnsiConsole.Ask<int>("Enter  ID:");
        try
        {
            string studentId = GetValidStudentId("Enter student Id: ");

            var student = studentService.GetByIdAsync(Id).Result;


            var newStudentname = AnsiConsole.Ask<string>("Enter new student name:");
            var newStudentSurname = AnsiConsole.Ask<string>("Enter new student surname:");
            string newEmail;
            do
            {
                newEmail = AnsiConsole.Ask<string>("Enter email:");

                if (!IsValidEmail(newEmail))
                {
                    AnsiConsole.WriteLine("Invalid email format or domain. Please enter a valid email address with the '@gmail.com' domain.");
                }
            } while (!IsValidEmail(newEmail));
            string newStudentId = GetValidStudentId("Enter new studentId: ");
            DateOnly birthOfDate = AnsiConsole.Ask<DateOnly>("Enter birth of date to update");
            string phoneNumber;
            do
            {
                phoneNumber = AnsiConsole.Ask<string>("Enter student's phone number to update:");
                if (!IsValidPhoneNumber(phoneNumber))
                {
                    AnsiConsole.WriteLine("Invalid phone number format");
                }
            } while (!IsValidPhoneNumber(phoneNumber));

            string parentsPhoneNumber;
            do
            {
                parentsPhoneNumber = AnsiConsole.Ask<string>("Enter parents new phone number:");
                if (!IsValidParentsPhoneNumber(parentsPhoneNumber))
                {
                    AnsiConsole.WriteLine("Invalid phone number format");
                }
            } while (!IsValidParentsPhoneNumber(parentsPhoneNumber));
reentertypecreate:

            await Console.Out.WriteLineAsync("Choose Majors:");
            await Console.Out.WriteLineAsync("1.Electrical_And_Computer_Engineering");
            await Console.Out.WriteLineAsync("2.Civil_Engineering");
            await Console.Out.WriteLineAsync("3.Architecture");
            await Console.Out.WriteLineAsync("4.English_Philology");
            await Console.Out.WriteLineAsync("5.Korean_Philology");
            string major = Console.ReadLine();
            StudentModel updateStudent = new StudentModel();
            switch (major)
            {
                case "1":
                    updateStudent.Majors = Convert.ToString(Majors.Electrical_And_Computer_Engineering);
                    break;
                case "2":
                    updateStudent.Majors = Convert.ToString(Majors.Civil_Engineering);
                    break;
                case "3":
                    updateStudent.Majors = Convert.ToString(Majors.Architecture);
                    break;
                case "4":
                    updateStudent.Majors = Convert.ToString(Majors.English_Philology);
                    break;
                case "5":
                    updateStudent.Majors = Convert.ToString(Majors.Korean_Philology);
                    break;
                default:
                    await Console.Out.WriteLineAsync("wrong choice, Press any key to re-enter");
                    goto reentertypecreate;
            }
            string nation = AnsiConsole.Ask<string>("Enter nation:");
reentertypegender:

            await Console.Out.WriteLineAsync("Choose Gender:");
            await Console.Out.WriteLineAsync("1.Male");
            await Console.Out.WriteLineAsync("2.Female");
            string gender = Console.ReadLine();
            switch (gender)
            {
                case "1":
                    updateStudent.Gender = Convert.ToString(Gender.Male);
                    break;
                case "2":
                    updateStudent.Gender = Convert.ToString(Gender.Female);
                    break;
                default:
                    await Console.Out.WriteLineAsync("wrong choice, Press any key to re-enter");
                    goto reentertypegender;
            }
reentertypeteacher:

            await Console.Out.WriteLineAsync("Choose Teacher:");
            await Console.Out.WriteLineAsync("1.Student must tuition fee $3000 for Native teacher");
            await Console.Out.WriteLineAsync("2.Student must tuition fee $2500 for Local teacher");
            await Console.Out.WriteLineAsync("3.Student must tuition fee $2700 for Native_And_Local_Teachers");
            string teachersType = Console.ReadLine();
            switch (teachersType)
            {
                case "1":
                    updateStudent.TeachersType = Convert.ToString(TeachersType.Native_Teachers);
                    break;
                case "2":
                    updateStudent.TeachersType = Convert.ToString(TeachersType.Local_Teachers);
                    break;
                case "3":
                    updateStudent.TeachersType = Convert.ToString(TeachersType.Native_And_Local_Teachers);
                    break;
                default:
                    await Console.Out.WriteLineAsync("wrong choice, Press any key to re-enter");
                    goto reentertypeteacher;
            }
            var updateStudentModel = new StudentUpdateModel
            {
                Name = newStudentname,
                SurName = newStudentSurname,
                BirthOfDate = birthOfDate,
                Parents_PhoneNumber = parentsPhoneNumber,
                PhoneNumber = phoneNumber,
                StudentId = Hashing(newStudentId),
                Email = newEmail,
                Gender = student.Gender,
                Nation = nation,
                Majors = student.Majors,
                TeachersType = student.TeachersType
                //subject
            };

            var result = studentService.UpdateAsync(Id, updateStudentModel).Result;
            AnsiConsole.WriteLine($"Student updated successfully! ID: {Id}");
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteLine($"Error: {ex.Message}");
        }
    }
    private void Delete()
    {
        var Id = AnsiConsole.Ask<int>("Enter  ID:");
        try
        {
            string studentId = GetValidStudentId("Enter private student id: ");

            var student = studentService.GetByIdAsync(Id).Result;
            if (VerifyStudentId(student.StudentId, student.StudentId))
            {
                Console.WriteLine("Incorrect studentId.");
                return;
            }
            var result = studentService.DeleteAsync(Id).Result;
            AnsiConsole.WriteLine($"Student with ID {Id} deleted successfully!");
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteLine($"Error: {ex.Message}");
        }
    }
    private bool VerifyStudentId(string actualHashedStudentId, string enteredStudentId)
    {
        string enteredHashedStudentId = Hashing(enteredStudentId);
        return actualHashedStudentId == enteredHashedStudentId;
    }

    private string Hashing(string enteredStudentId)
    {
        using (SHA256 hash = SHA256.Create())
        {
            byte[] hashedBytes = hash.ComputeHash(Encoding.UTF8.GetBytes(enteredStudentId));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }
    private string GetValidStudentId(string promptMessage)
    {
        string studentId;
        do
        {
            studentId = AnsiConsole.Prompt(
                 new TextPrompt<string>($"[green]{promptMessage}[/]")
                    .PromptStyle("red")
                    .Secret()).Trim();

            if (studentId.Length < 4)
            {
                AnsiConsole.MarkupLine("[red1]Student Id must have at least 4 characters.[/]");
            }
        } while (studentId.Length < 4);

        return studentId;
    }
}
