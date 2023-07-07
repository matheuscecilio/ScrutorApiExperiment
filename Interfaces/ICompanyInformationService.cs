using ScrutorApiExperiment.Dto;

namespace ScrutorApiExperiment.Interfaces;

public interface ICompanyInformationService
{
    public Task<CompanyDto> GetCompanyInformation(Guid id);
}
