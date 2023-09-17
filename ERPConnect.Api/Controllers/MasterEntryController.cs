using ERPConnect.Api.Interface;
using ERPConnect.Api.Models;
using ERPConnect.Models.Entity_Tables;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ERPConnect.Api.Controllers
{
    public class MasterEntryController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        public MasterEntryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetCompanyGroup")]
        public async Task<ApiResponse<IEnumerable<CompanyGroup>>> GetCompanyGroup()
        {
            var apiResponse = new ApiResponse<IEnumerable<CompanyGroup>>();

            try
            {
                var data = await _unitOfWork.MasterEntry.GetCompanyGroup();
                apiResponse.Success = true;
                apiResponse.Result = data;
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Logger.Instance.Error($"Exception Occured at {DateTime.Now}.Exception Details: {ex.Message}");
            }
            return apiResponse;
        }

        [HttpPost("UpdateCompanyGroup")]
        public async Task<ApiResponse<CompanyGroup>> UpdateCompanyGroup(CompanyGroup updatedCompanyGroup)
        {
            var apiResponse = new ApiResponse<CompanyGroup>();

            if (ModelState.IsValid)
            {
                try
                {
                    var updatedData = await _unitOfWork.MasterEntry.UpdateCompanyGroup(updatedCompanyGroup);
                    apiResponse.Success = true;
                    apiResponse.Result = updatedData;
                }
                catch (Exception ex)
                {
                    apiResponse.Success = false;
                    apiResponse.Message = ex.Message;
                    Logger.Instance.Error($"Exception Occured at {DateTime.Now}.Exception Details: {ex.Message}");
                }
            }
            else
            {
                // If ModelState is not valid, set validation errors in the response
                apiResponse.Success = false;
                apiResponse.Errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
            }

            return apiResponse;
        }

        [HttpPost("AddCompanyGroup")]
        public async Task<ApiResponse<CompanyGroup>> AddCompanyGroup(CompanyGroup newCompanyGroup)
        {
            var apiResponse = new ApiResponse<CompanyGroup>();

            if (ModelState.IsValid)
            {
                try
                {
                    var addedCompanyGroup = await _unitOfWork.MasterEntry.AddCompanyGroup(newCompanyGroup);
                    apiResponse.Success = true;
                    apiResponse.Result = addedCompanyGroup;
                }
                catch (Exception ex)
                {
                    apiResponse.Success = false;
                    apiResponse.Message = ex.Message;
                    Logger.Instance.Error($"Exception Occured at {DateTime.Now}.Exception Details: {ex.Message}");
                }
            }
            else
            {
                // If ModelState is not valid, set validation errors in the response
                apiResponse.Success = false;
                apiResponse.Errors = ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
            }

            return apiResponse;
        }

        [HttpDelete("DeleteCompanyGroup/{id}")]
        public async Task<IActionResult> DeleteCompanyGroup(int id)
        {
            var apiResponse = new ApiResponse<object>();

            try
            {
                // Retrieve the CompanyGroup by ID (if it exists)
                var companyGroup = await _unitOfWork.MasterEntry.GetCompanyGroupById(id);

                if (companyGroup == null)
                {
                    apiResponse.Success = false;
                    apiResponse.Message = "CompanyGroup not found";
                    return Ok(apiResponse);
                }
                // Delete the CompanyGroup from the database
                await _unitOfWork.MasterEntry.DeleteCompanyGroup(id);

                apiResponse.Success = true;
                apiResponse.Message = "CompanyGroup deleted successfully";
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Logger.Instance.Error($"Exception Occured at {DateTime.Now}.Exception Details: {ex.Message}");
            }
            return Ok(apiResponse);
        }

    }
}
