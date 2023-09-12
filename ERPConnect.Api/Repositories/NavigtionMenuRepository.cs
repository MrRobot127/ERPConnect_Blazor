using ERPConnect.Api.Interface;
using ERPConnect.Api.Models;
using ERPConnect.Models.Entity_Tables;
using Microsoft.EntityFrameworkCore;

namespace ERPConnect.Api.Repositories
{
    public class NavigtionMenuRepository : INavMenuRepository
    {
        private readonly AppDbContext _dbContext;

        public NavigtionMenuRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MenuItem>> GetNavMenuItems()
        {
            var menuItems = await _dbContext.MenuItem.ToListAsync();

            return menuItems;
        }

    }
}
