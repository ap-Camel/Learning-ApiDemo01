using APIDEMO01.Models;
using APIDEMO01.SQL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIDEMO01.Controllers {

    [ApiController]
    [Route("users")]
    public class UsersController {

        private readonly IUsersData usersData;

        public UsersController(IUsersData usersData) {
            this.usersData = usersData;
        }

        // [HttpGet]
        // public async Task<List<UsersModel>> getUsers() {

        //     return await usersData.getUsers();
        // }

        [HttpGet("{email}, {pass}")]
        public async Task<UsersModel> getUser(string email, string pass) {
            return await usersData.verifyUser(email, pass);
        }

        [HttpPost]
        public async Task<bool> insertUser(UsersModel user) {
            return await usersData.insertUser(user);
        }

        // public async Task<ActionResult<string>> login() {
        //     return "my token";
        // }
    }
}