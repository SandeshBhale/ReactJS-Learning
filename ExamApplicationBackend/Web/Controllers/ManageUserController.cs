using Core;
using Infra;
using Infra.Dto;
using Infra.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Web.Dto;

    namespace Web.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ManageUserController : ControllerBase
        {
            private readonly IUserRepo _urepo;
            private readonly IConfiguration _config;

            public ManageUserController(IConfiguration config,IUserRepo urepo)
            {
                _config = config;
                _urepo = urepo;
            }

            [HttpPost("register")]
            public async Task<IActionResult> Register([FromBody] SignUpDto rec)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var userExists = await _urepo.UserExistsAsync(rec.EmailId);

                if (userExists)
                    return BadRequest("User Already Exist !!");

                var user = new User
                {
                    FirstName = rec.FirstName,
                    LastName = rec.LastName,
                    EmailId = rec.EmailId,
                    MobileNo = rec.MobileNo,
                    Password = BCrypt.Net.BCrypt.HashPassword(rec.Password)
                };

                await this._urepo.AddUserAsync(user);

                return Ok("User Registred Successfully ! ");
            }

            [HttpPost("login")]
            public async Task<IActionResult> Login([FromBody] SignInDto rec)
            {

                var user = await _urepo.GetUserByEmailId(rec.EmailId);
                if (user == null || !BCrypt.Net.BCrypt.Verify(rec.Password, user.Password))
                    return Unauthorized("Invalid Credentials");

                var token = GenerateToken(user);
                return Ok(new { Token = token });
            }

            [HttpPost("changepassword")]
            public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto rec)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = await _urepo.GetUserByEmailId(rec.EmailId);
                var id = user.UserId;
                    if (user == null)
                        return NotFound("Admin Not Found !");

                if (!BCrypt.Net.BCrypt.Verify(rec.OldPassword, user.Password))
                        return BadRequest("Old Password is Incorrect !");

                rec.NewPassword = BCrypt.Net.BCrypt.HashPassword(rec.NewPassword);

                await this._urepo.ChangePasswordAsync(rec,id);

                return Ok("Password Changed Successfully !");
            }

            [NonAction]
            public string GenerateToken(User user)
            {
                var claims = new List<Claim> 
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.EmailId),
                new Claim("firstName", user.FirstName),
                new Claim("email", user.EmailId)
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

                var token = new JwtSecurityToken(
                    issuer: _config["JWT:issuer"],
                    audience: _config["JWT:audience"],
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }

        }
    }
