using ERPConnect.Models;

namespace ERPConnect.Api.Interface
{
    public interface IMasterEntryRepository
    {
        Task<List<CompanyGroup>> GetCompanyGroup();
    }
}
