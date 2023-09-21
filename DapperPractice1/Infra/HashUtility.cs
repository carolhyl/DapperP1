using BC = BCrypt.Net.BCrypt;

namespace DapperPractice1.Infra
{
	public class HashUtility
	{
		private readonly IConfiguration _configuration;
        public HashUtility(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public string GetSalt()
        {
            return _configuration["salt"];
        }

        public string ToBycrypt(string pwd)
        {
            return BC.HashPassword(pwd, GetSalt());
		}
    }
}
