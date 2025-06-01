using Core;
using Infra.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Web.Dto;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageAdminController : ControllerBase
    {
        public readonly IAdminRepo _arepo;
        public readonly IConfiguration _config;

        public ManageAdminController(IAdminRepo arepo, IConfiguration config)
        {
            _arepo = arepo;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]SignUpDto rec)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var adminExists = await this._arepo.AdminExistsAsync(rec.EmailId);
            if (adminExists)
                return BadRequest("Admin Already Exists !!!");

            var admin = new Admin
            {
                FirstName = rec.FirstName,
                LastName = rec.LastName,
                EmailId = rec.EmailId,
                MobileNo = rec.MobileNo,
                Password = BCrypt.Net.BCrypt.HashPassword(rec.Password)
            };

            await this._arepo.AddAdminAsync(admin);

            return Ok("Admin Registred Successfully !");

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] SignInDto rec)
        {
            var admin = await _arepo.GetAdminByEmailId(rec.EmailId);
            if (admin == null || !BCrypt.Net.BCrypt.Verify(rec.Password, admin.Password))
                return Unauthorized("Invalid Credentials !!!");

            var token = GenerateToken(admin);
            return Ok(new { Token = token });

        }

        [NonAction]
        public string GenerateToken(Admin admin)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,admin.EmailId),
                new Claim("firstName",admin.FirstName),
                new Claim("email",admin.EmailId)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                issuer: _config["JWT:issuer"],
                audience: _config["JWT:audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials:creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
