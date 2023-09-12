using ERPConnect.Api.Models;
using ERPConnect.Models.Entity_Tables;
using ERPConnect.Web.Interface;
using Newtonsoft.Json;

namespace ERPConnect.Web.Services
{
    public class MenuService : IMenuService
    {
        private readonly HttpClient httpClient;
        public MenuService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<MenuItem>> GetMenuItems()
        {
            var response = await httpClient.GetAsync("api/NavMenu/GetNavMenu");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;

                // Deserialize the JSON content into a list of CompanyGroup objects using JsonConvert
                // Deserialize the JSON content into a list of MenuItem objects using JsonConvert
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<MenuItem>>>(responseContent);

                if (apiResponse.Success)
                {
                    return apiResponse.Result;
                }
            }
            return new List<MenuItem>();
        }
    }
}
