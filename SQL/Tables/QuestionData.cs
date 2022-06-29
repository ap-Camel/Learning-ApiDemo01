using APIDEMO01.Models;
using APIDEMO01.SQL.Interfaces;

namespace APIDEMO01.SQL.Tables{
    

    public class QuestionData : IQuestionData
    {
        private readonly ISqlDataAccess _db;

        public QuestionData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<List<Question>> getQuestions()
        {
            string sql = $"select * from question";

            return await _db.LoadMany<Question>(sql);
        }

        public async Task<bool> insertQuestion(Question q){
            string sql = $"insert into question values ('{q.description}', {Convert.ToInt16(q.hasUrl)}, null, 'default', GETDATE(), {q.difficultyLvl});";

            return await _db.insertData(sql);
        }
    }
}