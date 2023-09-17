using ERPConnect.Models.Entity_Tables;

namespace ERPConnect.Api.Interface
{
    public interface IMasterEntryRepository
    {
        Task<IEnumerable<CompanyGroup>> GetCompanyGroup();
        Task<CompanyGroup> UpdateCompanyGroup(CompanyGroup updatedCompanyGroup);
        Task<CompanyGroup> AddCompanyGroup(CompanyGroup newcompanyGroup);
        Task<CompanyGroup> GetCompanyGroupById(int id);
        Task DeleteCompanyGroup(int id);
    }
}
