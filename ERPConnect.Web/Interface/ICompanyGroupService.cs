using ERPConnect.Models.Entity_Tables;

namespace ERPConnect.Web.Interface
{
    public interface ICompanyGroupService
    {
        Task<IEnumerable<CompanyGroup>> GetCompanyGroup();
        Task<CompanyGroup> UpdateCompanyGroup(CompanyGroup updatedCompanyGroup);
        Task<CompanyGroup> AddCompanyGroup(CompanyGroup newcompanyGroup);
        Task DeleteCompanyGroup(int id);

    }
}
