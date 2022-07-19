using System.ComponentModel.DataAnnotations;

namespace APIDEMO01.Dtos {
    public record LoginUser {
        [Required]
        public string email {get; init;}
        [Required]
        public string password {get; init;}
    }
}