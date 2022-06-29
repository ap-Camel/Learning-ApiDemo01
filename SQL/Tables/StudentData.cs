using APIDEMO01.Models;
using APIDEMO01.SQL.Interfaces;

namespace APIDEMO01.SQL.Tables {
    public class StudentData : IStudentData
    {

        private readonly ISqlDataAccess _db;

        public StudentData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<List<StudentModel>> GetStudents()
        {
            string sql = $"select * from student";

            return await _db.LoadMany<StudentModel>(sql);
        }
    }
}