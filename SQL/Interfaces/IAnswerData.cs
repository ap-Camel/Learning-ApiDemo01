using APIDEMO01.Dtos;
using APIDEMO01.Models;

namespace APIDEMO01.SQL.Interfaces{
    public interface IAnswerData
    {
        Task<List<Answer>> getAnswers(int id);

        Task<List<Answer>> answersDefault(int id);

        Task<bool> insertAnswer(InsertAnswer answer);
    }
}