using ERPConnect.Web.Interface;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using System.Net;
using ERPConnect.Models.Entity_Tables;

namespace ERPConnect.Web.RazorComponents
{
    public class CompanyGroupListBase : ComponentBase
    {
        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }
        [Inject]
        public ICompanyGroupService CompanyGroupService { get; set; }
        public IEnumerable<CompanyGroup> CompanyGroups { get; set; }

        protected override void OnInitialized()
        {
            var authenticationState = authenticationStateTask.Result;

            if (!authenticationState.User.Identity.IsAuthenticated)
            {
                string returnUrl = WebUtility.UrlEncode($"/MasterEntry/CompanyGroup");
                NavigationManager.NavigateTo($"/Identity/Account/Login?returnUrl={returnUrl}");
            }
            var user = authenticationState.User;

            CompanyGroups = CompanyGroupService.GetCompanyGroup();
        }
    }
}
