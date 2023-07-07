using Microsoft.AspNetCore.Mvc;
using ScrutorApiExperiment.Interfaces;

namespace ScrutorApiExperiment.Controllers;

[ApiController]
[Route("[controller]")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyInformationService _companyInformationService;

    public CompanyController(ICompanyInformationService companyInformationService)
    {
        _companyInformationService = companyInformationService;
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetCompanyInformationAsync(Guid id)
    {
        var companyDto = await _companyInformationService.GetCompanyInformation(id);

        if (companyDto is null)
        {
            return BadRequest("Company not found");
        }

        return Ok(companyDto);
    }
}
