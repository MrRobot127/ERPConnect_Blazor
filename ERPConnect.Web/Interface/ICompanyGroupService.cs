using ERPConnect.Models.Entity_Tables;

namespace ERPConnect.Web.Interface
{
    public interface ICompanyGroupService
    {
        IEnumerable<CompanyGroup> GetCompanyGroup();
    }
}
