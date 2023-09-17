using ERPConnect.Models.Entity_Tables;
using ERPConnect.Web.Interface;
using ERPConnect.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace ERPConnect.Web.Shared
{
    public class NavMenuBase : ComponentBase
    {
        [CascadingParameter] private Task<AuthenticationState> authenticationState { get; set; }

        [Inject] private NavigationManager NavigationManager { get; set; }

        [Inject] private IMenuService MenuService { get; set; }

        protected IEnumerable<MenuItem> menuList;
        protected Dictionary<int, bool> submenuVisibility = new Dictionary<int, bool>();

        protected override async Task OnInitializedAsync()
        {
            var authState = authenticationState.Result;

            if (!authState.User.Identity.IsAuthenticated)
            {
                NavigationManager.NavigateTo("/Identity/Account/Login");
            }
            else
            {
                menuList = await MenuService.GetMenuItems();
            }
        }
        protected async Task ToggleSubMenu(int menuItemId)
        {
            if (submenuVisibility.ContainsKey(menuItemId))
            {
                submenuVisibility[menuItemId] = !submenuVisibility[menuItemId];
            }
            else
            {
                submenuVisibility.Add(menuItemId, true);
            }
            StateHasChanged();
        }
    }
}
