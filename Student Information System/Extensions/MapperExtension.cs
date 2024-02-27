using Student_Information_System.Models.Student_Models;

namespace Student_Information_System.Extensions;

public static class MapperExtension
{
    #region STUDENT
    public static StudentModel ToMapped(this StudentCreationModel model)
    {
        return new StudentModel
        {
            StudentId = model.StudentId,
            Name = model.Name,
            SurName = model.SurName,
            Email = model.Email,
            BirthOfDate = model.BirthOfDate,
            PhoneNumber = model.PhoneNumber,
            Parents_PhoneNumber = model.Parents_PhoneNumber,
            Majors = model.Majors,
            Subjects = model.Subjects,
            Nation = model.Nation,
            Gender = model.Gender,
            TeachersType = model.TeachersType,
        };
    }
    public static StudentUpdateModel ToMap(this StudentCreationModel model)
    {
        return new StudentUpdateModel
        {
            StudentId = model.StudentId,
            Name = model.Name,
            SurName = model.SurName,
            Email = model.Email,
            BirthOfDate = model.BirthOfDate,
            PhoneNumber = model.PhoneNumber,
            Parents_PhoneNumber = model.Parents_PhoneNumber,
            Majors = model.Majors,
            Subjects = model.Subjects,
            Nation = model.Nation,
            Gender = model.Gender,
            TeachersType = model.TeachersType,
        };
    }
    public static StudentModel ToMap(this StudentUpdateModel model, int id)
    {
        return new StudentModel
        {
            Id = model.Id,
            StudentId = model.StudentId,
            Name = model.Name,
            SurName = model.SurName,
            Email = model.Email,
            BirthOfDate = model.BirthOfDate,
            PhoneNumber = model.PhoneNumber,
            Parents_PhoneNumber = model.Parents_PhoneNumber,
            Majors = model.Majors,
            Subjects = model.Subjects,
            Nation = model.Nation,
            Gender = model.Gender,
            TeachersType = model.TeachersType,
        };
    }
    public static StudentViewModel ToMap(this StudentModel model)
    {
        return new StudentViewModel
        {
            Id = model.Id,
            StudentId = model.StudentId,
            Name = model.Name,
            SurName = model.SurName,
            Email = model.Email,
            BirthOfDate = model.BirthOfDate,
            PhoneNumber = model.PhoneNumber,
            Parents_PhoneNumber = model.Parents_PhoneNumber,
            Majors = model.Majors,
            Subjects = model.Subjects,
            Nation = model.Nation,
            Gender = model.Gender,
            TeachersType = model.TeachersType,
        };
    }
    public static List<StudentViewModel> ToMap(this List<StudentModel> models)
    {
        var result = new List<StudentViewModel>();
        foreach (var model in models)
        {
            result.Add(new StudentViewModel
            {
                Id = model.Id,
                StudentId = model.StudentId,
                Name = model.Name,
                SurName = model.SurName,
                Email = model.Email,
                BirthOfDate = model.BirthOfDate,
                PhoneNumber = model.PhoneNumber,
                Parents_PhoneNumber = model.Parents_PhoneNumber,
                Majors = model.Majors,
                Subjects = model.Subjects,
                Nation = model.Nation,
                Gender = model.Gender,
                TeachersType = model.TeachersType,
            });
        }
        return result;
    }
    #endregion
}
