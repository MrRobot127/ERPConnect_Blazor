using ERPConnect.Models;

namespace ERPConnect.Web.Interface
{
    public interface ICompanyGroupService
    {
        IEnumerable<CompanyGroup> GetCompanyGroup();
    }
}
