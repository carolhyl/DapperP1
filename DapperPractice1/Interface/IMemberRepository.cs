using DapperPractice1.DTO.LoginDto;

namespace DapperPractice1.Interface
{
	public interface IMemberRepository
	{
		public Task<LoginDto> GetMemberByAccount(string account);
	}
}
