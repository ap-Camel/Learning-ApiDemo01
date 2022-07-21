using APIDEMO01.Models;

namespace APIDEMO01 {
    public record LoginReturn {

        // public record User {
        //     public string firstName {get; init;}
        //     public string lastName {get;init;}
        //     public string role {get;init;}
        //     public string email {get;init;}
        // }
        public string token {get; init;}
        public UsersModel user {get; init;}
        
    }
}