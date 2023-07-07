using Newtonsoft.Json;
using ScrutorApiExperiment.Dto;
using ScrutorApiExperiment.Interfaces;

namespace ScrutorApiExperiment.Services;

public class CachedCompanyInformationService : ICompanyInformationService
{
    private readonly ICompanyInformationService _companyInformationService;
    private readonly ICacheService _cacheService;

    public CachedCompanyInformationService(
        ICompanyInformationService companyInformationService,
        ICacheService cacheService
    )
    {
        _companyInformationService = companyInformationService;
        _cacheService = cacheService;
    }

    public async Task<CompanyDto> GetCompanyInformation(Guid id)
    {
        var stringId = id.ToString();

        var companyDtoFromCache = await _cacheService.GetCacheValueAsync(stringId);

        if (!string.IsNullOrEmpty(companyDtoFromCache))
        {
            return JsonConvert.DeserializeObject<CompanyDto>(companyDtoFromCache)!;
        }

        var companyDtoFromDatabase = await _companyInformationService.GetCompanyInformation(id);

        await _cacheService.SetCacheValueAsync(
            stringId,
            JsonConvert.SerializeObject(companyDtoFromDatabase),
            TimeSpan.FromSeconds(20)
        );

        return companyDtoFromDatabase;
    }
}
