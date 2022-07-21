using System.Security.Cryptography;
using System.Text;
using APIDEMO01.Dtos;
using APIDEMO01.Models;
using APIDEMO01.SQL.Interfaces;

namespace APIDEMO01.SQL.Tables {
    public class UsersData : IUsersData {
        private readonly ISqlDataAccess _db;

        public UsersData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<List<UsersModel>> getUsers() {
            string sql = "select * from users";

            return await _db.LoadMany<UsersModel>(sql);
        }

        public async Task<UsersModel> verifyUser(string email, string pass) {

            StringBuilder Sb = new StringBuilder();
            
            using(SHA256 myHash = SHA256.Create()) {
                Encoding enc = Encoding.UTF8;
                Byte[] result = myHash.ComputeHash(enc.GetBytes(pass));

                foreach (Byte b in result) {
                    Sb.Append(b.ToString("x2"));
                }
            }

            string sql = $"select top 1 * from users where email = '{email}' and CONVERT(varchar(255), pass) = '{Sb.ToString()}'";

            return await _db.LoadSingle<UsersModel>(sql);
        }

        public async Task<UsersModel> emailExists(string email) {
            string sql = $"select top 1 * from users where email = '{email}'";

            return await _db.LoadSingle<UsersModel>(sql);
        }

        public async Task<bool> insertUser(SignupUser user) {

            StringBuilder Sb = new StringBuilder();
            
            using(SHA256 myHash = SHA256.Create()) {
                Encoding enc = Encoding.UTF8;
                Byte[] result = myHash.ComputeHash(enc.GetBytes(user.password));

                foreach (Byte b in result) {
                    Sb.Append(b.ToString("x2"));
                }
            }

            string sql = $"insert into users values ('{user.firstName}', '{user.lastName}', '{user.role}', '{user.email}', '{Sb.ToString()}')";

            return await _db.insertData(sql);
        }
        

    }
}