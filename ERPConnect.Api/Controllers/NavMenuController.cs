using ERPConnect.Api.Interface;
using ERPConnect.Api.Models;
using ERPConnect.Models.Entity_Tables;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ERPConnect.Api.Controllers
{
    public class NavMenuController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        public NavMenuController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetNavMenu")]
        public async Task<ActionResult<ApiResponse<IEnumerable<MenuItem>>>> GetNavMenuItems()
        {
            var apiResponse = new ApiResponse<IEnumerable<MenuItem>>();

            try
            {
                var data = await _unitOfWork.NavigationMenu.GetNavMenuItems();
                apiResponse.Success = true;
                apiResponse.Result = data;
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                //Logger.Instance.Error($"Exception Occured at {DateTime.Now}.Exception Details: {ex.Message}");
            }
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                
            };

            return Content(JsonSerializer.Serialize(apiResponse, jsonSerializerOptions), "application/json");
        }
    }
}
