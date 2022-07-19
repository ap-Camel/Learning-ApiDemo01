using System.ComponentModel.DataAnnotations;

namespace APIDEMO01.Models {
    public record UsersModel {
        public int ID {get; init; }
         [Required]
        public string firstName { get; init; }
        public string lastName {get; init;}
         [Required]
        public string userType {get; init;}
         [Required]
        public string email {get; init;}
         [Required]
        public string pass {get; init;}
    }
}