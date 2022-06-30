using APIDEMO01.Models;

namespace APIDEMO01.Dtos{
    public record EvaluateExam {
        public int questionID { get; init; }
        public string answer { get; init; }
    }
}