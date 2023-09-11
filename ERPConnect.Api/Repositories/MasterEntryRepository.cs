using ERPConnect.Api.Interface;
using ERPConnect.Api.Models;
using ERPConnect.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPConnect.Api.Repositories
{
    public class MasterEntryRepository : IMasterEntryRepository
    {
        private readonly AppDbContext _dbContext;
        public MasterEntryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<CompanyGroup>> GetCompanyGroup()
        {
            try
            {
                var lstcompanyGroup = await _dbContext.CompanyGroup.Where(group => group.IsActive == true).ToListAsync();

                return lstcompanyGroup;
            }
            catch
            {
                throw;
            }
        }
    }
}
