using ERPConnect.Api.Interface;

namespace ERPConnect.Api.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        public IMasterEntryRepository MasterEntry { get; set; }
        public UnitOfWork(
                           IMasterEntryRepository master
                         )
        {
            MasterEntry = master;
        }
        
    }
}
