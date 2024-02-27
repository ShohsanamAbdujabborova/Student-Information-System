using Student_Information_System.Models.Student_Models;
namespace Student_Information_System.Interfaces;
public interface IStudentService
{
    /// <summary>
    /// this method for creating new student
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    ValueTask<StudentViewModel> CreateAsync(StudentCreationModel model);
    /// <summary>
    /// this method for updating existing student
    /// </summary>
    /// <param name="id"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    ValueTask<bool> UpdateAsync(int id, StudentUpdateModel model);
    /// <summary>
    /// this method for deleting exist student
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ValueTask<bool> DeleteAsync(int id);
    /// <summary>
    /// this method for getting exist students by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ValueTask<StudentViewModel> GetByIdAsync(int id);
    /// <summary>
    /// this method for getting all students from students.json inside Data folder
    /// </summary>
    /// <returns></returns>
    ValueTask<List<StudentViewModel>> GetAllAsync();
    /// <summary>
    /// this method for searching student by key from students.json inside Data folder
    /// </summary>
    /// <param name="searchTerm"></param>
    /// <returns></returns>
    ValueTask<List<StudentViewModel>> SearchStudentsAsync(string searchTerm);
}
