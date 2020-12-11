using System;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using offerpay.Models;
using ServiceStack.Auth;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace offerpay.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private IConfiguration _config;
		private readonly offerpaydbContext _context;
		public LoginController(IConfiguration config, offerpaydbContext context)
		{
			_config = config;
			_context = context;
		}
		[HttpPost]
		public async Task<ActionResult<User>> Register(User user)
		{
			if (_context.User.Where(x => x.Username == user.Username).Any())
			{
				return Conflict();
			}
			string hash, salt;
			new SaltedHash().GetHashAndSaltString(user.Password,out hash,out salt);
			user.Password = hash;
			user.Salt = salt;
			user.Role = "registered";
			_context.User.Add(user);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetUser","Users", new { id = user.Id }, user);
		}
		public IActionResult Login(string username,string pass)
		{
			IActionResult result = Unauthorized();
			var user =_context.User.Where(x => x.Username == username).SingleOrDefault();
			if (user!= null && new SaltedHash().VerifyHashString(pass, user.Password, user.Salt)) 
			{
				var tokenStr = GenerateToken(user);
				result = Ok(new { token = tokenStr });
			}
			return result;
		}
		
		private string GenerateToken(User user)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			var claims = new[]
			{
				new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub,user.Username),
				new Claim(ClaimTypes.Role,user.Role),
				new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
				new Claim("id",user.Id.ToString())

			};
			var token = new JwtSecurityToken(
				issuer: _config["Jwt:Issuer"],
				audience: _config["Jwt:Issuer"],
				claims,
				expires: DateTime.Now.AddMinutes(120),
				signingCredentials: credentials
				);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
