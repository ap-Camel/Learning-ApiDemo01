using APIDEMO01.Models;

namespace APIDEMO01.Dtos{
    public record ExamQuestions{
        public Question question { get; init; }
        public List<Answer> answers { get; init; }
    }
}