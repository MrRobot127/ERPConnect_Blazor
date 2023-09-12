namespace ERPConnect.Api.Interface
{
    public interface IUnitOfWork
    {
        public IMasterEntryRepository MasterEntry { get; set; }
        public INavMenuRepository NavigationMenu { get; set; }
    }
}
