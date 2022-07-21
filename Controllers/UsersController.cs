using APIDEMO01.Dtos;
using APIDEMO01.Models;
using APIDEMO01.SQL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIDEMO01.Controllers {

    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase {

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
        public async Task<ActionResult<SignupUser>> insertUser(SignupUser user) {

            UsersModel verify = await usersData.emailExists(user.email);
            if(verify is null) {
                bool result = await usersData.insertUser(user);
                 if(result) {
                return Ok(user);
                }
            } else {
                return Conflict("email already exists");
            }
            
            return BadRequest("sign up was not successful");
        }

        // public async Task<ActionResult<string>> login() {
        //     return "my token";
        // }
    }
}