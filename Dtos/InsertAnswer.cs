using System.ComponentModel.DataAnnotations;

namespace APIDEMO01.Dtos{
    public record InsertAnswer{
        [Required]
        public bool answerType { get; init; }
        [Required]
        public string description { get; init; }
        public int answerPriority { get; init; }
        public int questionID { get; init; }
    }
}