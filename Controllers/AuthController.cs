using Microsoft.AspNetCore.Mvc;
using APIDEMO01.Models;
using APIDEMO01.SQL;
using APIDEMO01.SQL.Tables;
using APIDEMO01.SQL.Interfaces;
using APIDEMO01.Dtos;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace APIDEMO01.Controllers {

    [ApiController]
    [Route("token")]
    public class AuthController : ControllerBase {

        private readonly IUsersData usersData;
        private readonly IConfiguration config;

        public AuthController(IUsersData usersData, IConfiguration config) {
            this.usersData = usersData;
            this.config = config;
        }

        [HttpPost]
        public async Task<ActionResult<string>> logIn(LoginUser loginUser) {

            var user = await usersData.verifyUser(loginUser.email, loginUser.password);

            if(user is null) {
                return BadRequest("Invalid credentials");
            }

            return Ok(createToken(user));            
        }


        private string createToken(UsersModel user) {

            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.firstName),
                new Claim(ClaimTypes.Role, user.userType),
                new Claim("ID", user.ID.ToString()),
                new Claim(ClaimTypes.Email, user.email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["AppSettings:Token"]));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                        claims: claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}