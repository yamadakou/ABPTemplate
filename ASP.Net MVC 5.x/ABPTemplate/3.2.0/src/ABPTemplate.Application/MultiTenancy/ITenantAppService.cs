using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ABPTemplate.MultiTenancy.Dto;

namespace ABPTemplate.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
