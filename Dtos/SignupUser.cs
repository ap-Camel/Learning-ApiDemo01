using System.ComponentModel.DataAnnotations;

namespace APIDEMO01.Dtos {
    public record SignupUser {
        [Required]
        public string firstName {get; init;}
        [Required]
        public string lastName {get; init;}
        [Required]
        public string role {get; init;}
        [Required]
        public string email {get; init;}
        [Required]
        public string password {get; init;}
    }
}