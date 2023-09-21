using Dapper;
using DapperPractice1.Context;
using DapperPractice1.DTO;
using DapperPractice1.Interface;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace DapperPractice1.Repository
{
	public class CompanyRepository : ICompanyRepository
	{
		private readonly DapperContext _context;
		public CompanyRepository(DapperContext context) => _context = context;

		public async Task<CompanyDto> CreateCompany(CompanyCreateDto dto)
		{
			var sql = @"Insert into Companies (Name,Address,Country)
values (@Name, @Address, @Country)
select cast(scope_Identity() as int)";
			var param = new DynamicParameters();
			param.Add("Name", dto.Name, DbType.String);
			param.Add("Address", dto.Address, DbType.String);
			param.Add("Country", dto.Country, DbType.String);

			using (var conn = _context.CreateConnection())
			{
				//await conn.ExecuteAsync(sql, param);
				var Id = await conn.QuerySingleAsync<int>(sql, param);
				var newCompo = new CompanyDto
				{
					Id = Id,
					Name = dto.Name,
					Address = dto.Address,
					Country = dto.Country
				};
				return newCompo;
			}
		}

		public async Task CreateMultipleCompany(List<CompanyCreateDto> dto)
		{
			var sql = @"Insert into Companies (Name,Address,Country)
values(@Name,@Address,@Country)";

			using(var conn = _context.CreateConnection())
			{
				conn.Open();
				using(var transaction = conn.BeginTransaction())
				{
					foreach (var company in dto)
					{
						var param = new DynamicParameters();
						param.Add("Name",company.Name, DbType.String);
						param.Add("Address",company.Address, DbType.String);
						param.Add("Country",company.Country, DbType.String);

						await conn.ExecuteAsync(sql, param, transaction:transaction);
					}
					transaction.Commit();
				}
			}
		}

		public async Task DeleteCompany(int id)
		{
			var sql = "delete from companies where Id = @Id";
			using (var conn = _context.CreateConnection())
			{
				await conn.ExecuteAsync(sql, new { id });
			}
		}

		public async Task<IEnumerable<CompanyDto>> GetCompanies()
		{
			var sql = "select Id,Name as CompanyName,Address,Country from Companies";
			using (var conn = _context.CreateConnection())
			{
				var companies = await conn.QueryAsync<CompanyDto>(sql);
				return companies.ToList();
			}
		}

		public async Task<CompanyDto> GetCompany(int id)
		{
			var sql = "select * from Companies where Id = @Id";
			using (var conn = _context.CreateConnection())
			{
				var company = await conn.QuerySingleOrDefaultAsync<CompanyDto>(sql, new { id });
				return company;
			}
		}

		public async Task<CompanyDto> GetCompanyByEmpId(int id)
		{
			var processureName = "GetCompanyByEmployeeId";
			var param = new DynamicParameters();
			param.Add("Id", id, DbType.Int32, ParameterDirection.Input);

			using (var conn = _context.CreateConnection())
			{
				var company = await conn.QueryFirstOrDefaultAsync<CompanyDto>(processureName, param, commandType: CommandType.StoredProcedure);
				return company;
			}
		}

		public async Task<CompanyDto> MutipleResult(int id)
		{
			var sql = @"select * from Companies where id = @id
select * from Employees where companyId = @Id";
			using (var conn = _context.CreateConnection())
			using (var multi = await conn.QueryMultipleAsync(sql, new { id }))
			{
				var company = await multi.ReadSingleOrDefaultAsync<CompanyDto>();
				if (company is not null)
				{
					company.Employees = (await multi.ReadAsync<EmployeeDto>()).ToList();
				}
				return company;
			}
		}

		public async Task<List<CompanyDto>> MutipleResult()
		{
			var sql = @"select * from companies c 
left join employees e 
on c.Id = e.CompanyId";

			using (var conn = _context.CreateConnection())
			{
				var compoDic = new Dictionary<int, CompanyDto>();
				var companies = await conn.QueryAsync<CompanyDto, EmployeeDto, CompanyDto>(
					sql, (company, employee) =>
					{
						if (!compoDic.TryGetValue(company.Id, out var currentCompany))
						{
							currentCompany = company;
							compoDic.Add(currentCompany.Id, currentCompany);
						}
						currentCompany.Employees.Add(employee);
						return currentCompany;
					});
				return companies.Distinct().ToList();
			}
		}

		public async Task UpdateCompany(CompanyUpdateDto dto)
		{
			var sql = @"Update Companies 
set Name = @Name, Address = @Address, Country = @Country
where Id = @Id";

			var param = new DynamicParameters();
			param.Add("Id", dto.Id, DbType.Int32);
			param.Add("Name", dto.Name, DbType.String);
			param.Add("Address", dto.Address, DbType.String);
			param.Add("Country", dto.Country, DbType.String);

			using (var conn = _context.CreateConnection())
			{
				await conn.ExecuteAsync(sql, param);
			}
		}

	}
}
