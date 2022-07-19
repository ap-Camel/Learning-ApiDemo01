using APIDEMO01.Models;

namespace APIDEMO01.SQL.Interfaces {
    public interface IUsersData {
        
        Task<List<UsersModel>> getUsers();
        Task<UsersModel> verifyUser(string email, string pass);
        Task<bool> insertUser(UsersModel user);
        
    }
}