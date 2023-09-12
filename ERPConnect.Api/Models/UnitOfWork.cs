using ERPConnect.Api.Interface;

namespace ERPConnect.Api.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        public IMasterEntryRepository MasterEntry { get; set; }
        public INavMenuRepository NavigationMenu { get; set; }
        public UnitOfWork(
                           IMasterEntryRepository master,
                            INavMenuRepository menu
                         )
        {
            MasterEntry = master;
            NavigationMenu = menu;
        }

    }
}
