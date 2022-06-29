using System.ComponentModel.DataAnnotations;

namespace APIDEMO01.Models {
    public record InsertQuestion{
        [Required]
        public string description {get; init;}
        [Required]
        public bool hasUrl { get; init; }
        public string pictureUrl { get; init; }
        [Required]
        public string questionType { get; init; }
        public int difficultyLvl { get; init; }
    }
}