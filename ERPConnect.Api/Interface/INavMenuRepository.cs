using ERPConnect.Models.Entity_Tables;

namespace ERPConnect.Api.Interface
{
    public interface INavMenuRepository
    {
      Task<IEnumerable<MenuItem>> GetNavMenuItems();
    }
}
