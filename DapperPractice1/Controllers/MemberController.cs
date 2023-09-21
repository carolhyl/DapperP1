using DapperPractice1.DTO.LoginDto;
using DapperPractice1.Infra;
using DapperPractice1.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DapperPractice1.Controllers
{
	[Route("api/Account")]
	[ApiController]
	[AllowAnonymous]
	public class MemberController : ControllerBase
	{
		private readonly IMemberRepository _memberRepository;
		private readonly HashUtility _hashUtility;
		private readonly IConfiguration _configuration;
        public MemberController(IMemberRepository memberRepo,HashUtility hashUtility,IConfiguration configuration)
        {
            _memberRepository = memberRepo;
			_hashUtility = hashUtility;
			_configuration = configuration;
        }
        [HttpPost]
		public async Task<IActionResult> Login(LoginDto dto)
		{
			var memberInDb = await _memberRepository.GetMemberByAccount(dto.Account);
			if (memberInDb == null) return BadRequest("帳密有誤");

			//var hashPwd = _hashUtility.ToBycrypt(dto.Password);
			//if (string.Compare(hashPwd, memberInDb.Password) != 0) return BadRequest("帳密有誤");
			if (string.Compare(dto.Password, memberInDb.Password) != 0) return BadRequest("帳密有誤");

			var claims = new List<Claim>
			{
				new Claim("Account",memberInDb.Account),
				new Claim("Id",memberInDb.Id.ToString()),
			};

			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

			// 設定 JWT 相關資訊
			var jwt = new JwtSecurityToken
			(
				issuer: _configuration["JWT:Issuer"],
				audience: _configuration["JWT:Audience"],
				claims: claims,
				expires: DateTime.Now.AddMinutes(30),
				signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
			);

			// 產生JWT Token
			var token = new JwtSecurityTokenHandler().WriteToken(jwt);
			return Ok(token);
		}
	}
}
