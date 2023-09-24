using ERPConnect.Api.Models;
using ERPConnect.Models.Entity_Tables;
using ERPConnect.Web.Interface;
using Newtonsoft.Json;
using System.Text;

namespace ERPConnect.Web.Services
{
    public class CompanyGroupService : ICompanyGroupService
    {
        private readonly HttpClient httpClient;
        public CompanyGroupService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<CompanyGroup>> GetCompanyGroup()
        {
            var response = await httpClient.GetAsync("api/MasterEntry/GetCompanyGroup");

            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON content into a list of CompanyGroup objects using JsonConvert
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<CompanyGroup>>>(jsonContent);

                if (apiResponse.Success)
                {
                    return apiResponse.Result;
                }
                else
                {
                    // Handle the case where the API response indicates failure
                    throw new Exception($"Failed to retrieve CompanyGroups. Error message: {apiResponse.Message}");
                }
            }
            else
            {
                // Handle the case where the HTTP request itself is not successful
                throw new HttpRequestException($"Error retrieving CompanyGroups. Status code: {response.StatusCode}");
            }
        }

        public async Task<CompanyGroup> UpdateCompanyGroup(CompanyGroup updatedCompanyGroup)
        {
            try
            {
                // Serialize the updatedCompanyGroup to JSON
                var jsonContent = JsonConvert.SerializeObject(updatedCompanyGroup);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Send an HTTP POST request to update the CompanyGroup
                var response = await httpClient.PostAsync("api/MasterEntry/UpdateCompanyGroup", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response into a ApiResponse object
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<CompanyGroup>>(responseContent);

                    if (apiResponse.Success)
                    {
                        return apiResponse.Result;
                    }
                    else
                    {
                        // Handle the case where the API response indicates failure
                        throw new Exception($"Failed to update CompanyGroup. API response indicates failure: {apiResponse.Message}");
                    }
                }
                else
                {
                    // Handle the case where the HTTP POST request is not successful
                    throw new HttpRequestException($"Error updating CompanyGroup. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the update process
                throw new Exception($"Failed to update CompanyGroup. Error message: {ex.Message}", ex);
            }
        }

        public async Task<CompanyGroup> AddCompanyGroup(CompanyGroup newCompanyGroup)
        {
            try
            {
                // Serialize the newCompanyGroup to JSON
                var jsonContent = JsonConvert.SerializeObject(newCompanyGroup);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Send an HTTP POST request to add the CompanyGroup
                var response = await httpClient.PostAsync("api/MasterEntry/AddCompanyGroup", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response into a ApiResponse object
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<CompanyGroup>>(responseContent);

                    if (apiResponse.Success)
                    {
                        return apiResponse.Result;
                    }
                    else
                    {
                        // Handle the case where the API response indicates failure
                        throw new Exception($"Failed to add CompanyGroup. API response indicates failure: {apiResponse.Message}");
                    }
                }
                else
                {
                    // Handle the case where the HTTP POST request is not successful
                    throw new HttpRequestException($"Error adding CompanyGroup. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the add process
                throw new Exception($"Failed to add CompanyGroup. Error message: {ex.Message}", ex);
            }
        }
        public async Task DeleteCompanyGroup(int id)
        {
            // Send an HTTP DELETE request to delete the CompanyGroup by id
            var response = await httpClient.DeleteAsync($"api/MasterEntry/DeleteCompanyGroup/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON content into an ApiResponse object
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<object>>(jsonContent);

                if (!apiResponse.Success)
                {
                    // Handle the case where the API response indicates failure
                    throw new Exception($"Failed to delete CompanyGroup. Error message: {apiResponse.Message}");
                }
            }
            else
            {
                // Handle the case where the HTTP DELETE request is not successful
                throw new HttpRequestException($"Error deleting CompanyGroup. Status code: {response.StatusCode}");
            }
        }
    }
}
