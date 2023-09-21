using Dapper;
using DapperPractice1.Context;
using DapperPractice1.DTO.LoginDto;
using DapperPractice1.Interface;
using System.Data;

namespace DapperPractice1.Repository
{
	public class MemberRepository : IMemberRepository
	{
		private readonly DapperContext _context;
		public MemberRepository(DapperContext context)
		{
			_context = context;
		}

		public async Task<LoginDto> GetMemberByAccount(string account)
		{
			var sql = "select * from Member where Account = @Account";
			using (var conn = _context.CreateConnection())
			{
				return await conn.QueryFirstOrDefaultAsync<LoginDto>(sql, new { Account = account });
			}
		}
	}
}
