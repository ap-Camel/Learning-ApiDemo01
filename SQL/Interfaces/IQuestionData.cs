using APIDEMO01.Models;

namespace APIDEMO01.SQL.Interfaces{
    public interface IQuestionData
    {
        Task<List<Question>> getQuestions();
        Task<bool> insertQuestion(Question q);
    }
}