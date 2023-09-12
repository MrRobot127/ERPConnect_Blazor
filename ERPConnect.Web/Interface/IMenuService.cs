using ERPConnect.Models.Entity_Tables;

namespace ERPConnect.Web.Interface
{
    public interface IMenuService
    {
        Task<IEnumerable<MenuItem>> GetMenuItems();
    }
}
