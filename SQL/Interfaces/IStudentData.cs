using APIDEMO01.Models;


namespace APIDEMO01.SQL.Interfaces {
    public interface IStudentData {
        Task<List<StudentModel>> GetStudents();
    }
}