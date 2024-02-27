using Student_Information_System.Configuration;
using Student_Information_System.Extensions;
using Student_Information_System.Helpers;
using Student_Information_System.Interfaces;
using Student_Information_System.Models.Student_Models;
namespace Student_Information_System.Services.StudentService;
public class StudentModelService : IStudentService
{
#pragma warning disable
    private List<StudentModel> students;

    public async ValueTask<StudentViewModel> CreateAsync(StudentCreationModel StudentModel)
    {
        students = await FileIO.ReadAsync<StudentModel>(Constants.STUDENTS_PATH);
        var createdStudentModel = students.Create(StudentModel.ToMapped());
        await FileIO.WriteAsync(Constants.STUDENTS_PATH, students);
        return createdStudentModel.ToMap();
    }
    public async ValueTask<bool> DeleteAsync(int id)
    {
        students = await FileIO.ReadAsync<StudentModel>(Constants.STUDENTS_PATH);
        var existStudentModel = students.FirstOrDefault(p => p.Id == id && !p.IsDeleted)
            ?? throw new Exception($"StudentModel is not found with this id -> {id}");

        existStudentModel.IsDeleted = true;
        existStudentModel.DeletedAt = DateTime.UtcNow;
        await FileIO.WriteAsync(Constants.STUDENTS_PATH, students);
        return true;
    }

    public async ValueTask<List<StudentViewModel>> GetAllAsync()
    {
        students = await FileIO.ReadAsync<StudentModel>(Constants.STUDENTS_PATH);
        students = students.Where(p => !p.IsDeleted).ToList();
        if (students.Count <= 0 || students == null)
        {
            throw new Exception("There are no any students now");
        }
        return students.ToMap();
    }
    public async ValueTask<StudentViewModel> GetByIdAsync(int id)
    {
        students = await FileIO.ReadAsync<StudentModel>(Constants.STUDENTS_PATH);
        var existStudentModel = students.FirstOrDefault(p => p.Id == id && !p.IsDeleted)
            ?? throw new Exception($"StudentModel is not found with this id -> {id}");
        return existStudentModel.ToMap();
    }

    public async ValueTask<List<StudentViewModel>> SearchStudentsAsync(string searchTerm)
    {
        searchTerm = searchTerm.Trim().ToLower();
        students = await FileIO.ReadAsync<StudentModel>(Constants.STUDENTS_PATH);
        students = students.Where(p => !p.IsDeleted).ToList()
            ?? throw new Exception("No any users found to match");
        var res = new List<StudentViewModel>();
        foreach (var StudentModel in students)
        {
            if (StudentModel.Name.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase)
                || searchTerm.Contains(StudentModel.Name, StringComparison.CurrentCultureIgnoreCase)
                || StudentModel.Email.Equals(searchTerm, StringComparison.Ordinal))
            {
                res.Add(StudentModel.ToMap());
            }
        }
        if (res.Count <= 0 || res is null)
        {
            throw new Exception($"No any students found matching to this {searchTerm} keyword");
        }
        return res;
    }
    public async ValueTask<bool> UpdateAsync(int id, StudentUpdateModel model)
    {
        students = await FileIO.ReadAsync<StudentModel>(Constants.STUDENTS_PATH);
        var existStudentModel = students.FirstOrDefault(p => p.Id == id && !p.IsDeleted)
            ?? throw new Exception($"StudentModel is not found with this id -> {id}");

        existStudentModel.StudentId = model.StudentId;
        existStudentModel.Name = model.Name;
        existStudentModel.SurName = model.SurName;
        existStudentModel.BirthOfDate = model.BirthOfDate;
        existStudentModel.Email = model.Email;
        existStudentModel.PhoneNumber = model.PhoneNumber;
        existStudentModel.Parents_PhoneNumber = model.Parents_PhoneNumber;
        existStudentModel.Majors = model.Majors;
        //existStudentModel.Subjects = model.Subjects;
        existStudentModel.Nation = model.Nation;
        existStudentModel.Gender = model.Gender;
        existStudentModel.TeachersType = model.TeachersType;
        existStudentModel.UpdatedAt = DateTime.UtcNow;

        await FileIO.WriteAsync(Constants.STUDENTS_PATH, students);
        return true;
    }
}



