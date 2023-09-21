using DapperPractice1.DTO;
using DapperPractice1.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperPractice1.Controllers
{
	[Route("api/company")]
	[ApiController]
	//[Authorize]
	public class CompaniesController : ControllerBase
	{
		private readonly ICompanyRepository _CompoRepo;
		public CompaniesController(ICompanyRepository CompoRepo) => _CompoRepo = CompoRepo;

		[HttpGet]
		public async Task<IActionResult> GetCompanies()
		{
			var companies = await _CompoRepo.GetCompanies();
			return Ok(companies);
		}

		[HttpGet("{Id}",Name ="GetCompanyById")]
		public async Task<IActionResult> GetCompany(int Id)
		{
			if (Id < 1) return NotFound();
			var comany = await _CompoRepo.GetCompany(Id);
			return Ok(comany);
		}

		[HttpPost]
		public async Task<IActionResult> CreateCompony([FromBody]CompanyCreateDto dto)
		{
			var company = await _CompoRepo.CreateCompany(dto);

			return CreatedAtRoute("GetCompanyById", new { Id = company.Id }, company);
		}

		[HttpPost]
		[Route("UpdateCompony")]
		public async Task<IActionResult> UpdateCompany([FromBody]CompanyUpdateDto dto)
		{
			var toUpdate = _CompoRepo.GetCompany(dto.Id);
			if (toUpdate == null) return NotFound();

			await _CompoRepo.UpdateCompany(dto);
			return Ok($"已修改!{dto}");
		}
		[HttpDelete("{Id}")]
		public async Task<IActionResult> DeleteCompany(int Id)
		{
			var toDelete = _CompoRepo.GetCompany(Id);
			if (toDelete == null) return NotFound();

			await _CompoRepo.DeleteCompany(Id);
			return Ok($"已刪除!Id:{Id}");
		}

		[HttpGet("GetCompanyByEmpId/{Id}")]
		public async Task<IActionResult> GetCompanyByEmpId(int Id)
		{
			var company = await _CompoRepo.GetCompanyByEmpId(Id);
			if (company is null) return NotFound();

			return Ok(company);
		}

		[HttpGet("MutipleResult/{id}")]
		public async Task<IActionResult> MutipleResult(int id)
		{
			var company = await _CompoRepo.MutipleResult(id);
			if (company is null) return NotFound();

			return Ok(company);
		}

		[HttpGet("MultipleMappling")]
		public async Task<IActionResult> MutipleMapping()
		{
			var companies = await _CompoRepo.MutipleResult();
			return Ok(companies);
		}

		[HttpPost("CreateListCompanies")]
		public async Task<IActionResult> CreateAtOnce([FromBody]List<CompanyCreateDto> dto)
		{
		    await _CompoRepo.CreateMultipleCompany(dto);

			return Ok("批次創建成功!");
		}
    }
}
