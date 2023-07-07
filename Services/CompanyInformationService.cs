using Bogus;
using ScrutorApiExperiment.Dto;
using ScrutorApiExperiment.Interfaces;

namespace ScrutorApiExperiment.Services;

public class CompanyInformationService : ICompanyInformationService
{
    private readonly Faker _faker = new();

    public Task<CompanyDto> GetCompanyInformation(Guid id)
    {
        var companyDto = new CompanyDto(
            id,
            _faker.Company.CompanyName()
        );

        return Task.FromResult(companyDto);
    }
}
