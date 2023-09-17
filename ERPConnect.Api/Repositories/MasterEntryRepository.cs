using ERPConnect.Api.Interface;
using ERPConnect.Api.Models;
using ERPConnect.Models.Entity_Tables;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ERPConnect.Api.Repositories
{
    public class MasterEntryRepository : IMasterEntryRepository
    {
        private readonly AppDbContext _dbContext;
        public MasterEntryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<CompanyGroup>> GetCompanyGroup()
        {
            try
            {
                var lstcompanyGroup = await _dbContext.CompanyGroup.ToListAsync();

                return lstcompanyGroup;
            }
            catch
            {
                throw;
            }
        }

        public async Task<CompanyGroup> UpdateCompanyGroup(CompanyGroup updatedCompanyGroup)
        {
            try
            {
                var existingGroup = await _dbContext.CompanyGroup.FindAsync(updatedCompanyGroup.Id);

                if (existingGroup != null)
                {
                    existingGroup.GroupName = updatedCompanyGroup.GroupName;
                    existingGroup.IsActive = updatedCompanyGroup.IsActive;

                    existingGroup.ModifiedBy = 1; //will change once User Functionality added
                    existingGroup.ModifiedOn = DateTime.Now;

                    await _dbContext.SaveChangesAsync();
                    return existingGroup;
                }
                else
                {
                    throw new Exception("Group doesn't exist.");
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<CompanyGroup> AddCompanyGroup(CompanyGroup newCompanyGrup)
        {
            try
            {
                newCompanyGrup.CreatedBy = 1; //will change once User Functionality added
                newCompanyGrup.CreatedOn = DateTime.Now;

                _dbContext.CompanyGroup.Add(newCompanyGrup);
                await _dbContext.SaveChangesAsync();

                return newCompanyGrup;
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteCompanyGroup(int id)
        {
            try
            {
                var companyGroup = await _dbContext.CompanyGroup.FindAsync(id);

                if (companyGroup != null)
                {
                    _dbContext.CompanyGroup.Remove(companyGroup);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CompanyGroup> GetCompanyGroupById(int id)
        {
            try
            {
                var companyGroup = await _dbContext.CompanyGroup.FirstOrDefaultAsync(c => c.Id == id);
                return companyGroup;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
