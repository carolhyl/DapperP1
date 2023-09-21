using DapperPractice1.DTO;

namespace DapperPractice1.Interface
{
	public interface ICompanyRepository
	{
		public Task<IEnumerable<CompanyDto>> GetCompanies();
		public Task<CompanyDto> GetCompany(int id);
		public Task<CompanyDto> CreateCompany(CompanyCreateDto dto);
		public Task UpdateCompany(CompanyUpdateDto dto);
		public Task DeleteCompany(int id);
		public Task<CompanyDto> GetCompanyByEmpId(int id);
		public Task<CompanyDto> MutipleResult(int id);
		public Task<List<CompanyDto>> MutipleResult();
		public Task CreateMultipleCompany(List<CompanyCreateDto> dto);

	}
}
