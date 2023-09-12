using ERPConnect.Models.Entity_Tables;

namespace ERPConnect.Api.Interface
{
    public interface IMasterEntryRepository
    {
        Task<List<CompanyGroup>> GetCompanyGroup();
    }
}
