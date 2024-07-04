using MvcApiCallingService.Helpers.ApiHelper;
using RedCloud.Application.Features.Reseller.AssignCredit.Queries;
using RedCloud.Domain.Common;
using RedCloud.Domain.Entities;
using RedCloud.Interfaces;
using RedCloud.ViewModel;

namespace RedCloud.Services
{
	public class ResellerAssignCreditService : IResellerAssignCreditService
	{
		private readonly IApiClient<OrganizationAdmin> _apiClientOrganizationAdmin;
		private readonly IApiClient<CreditsType> _apiClientCreditsType;
		private readonly IApiClient<RateAssignCreditVM> _apiClientRateAssignCredit;
		private readonly IApiClient<GetAllAssignCredit> _apiClientGetAllAssignCredit;
		private readonly IApiClient<AssignCreditDetailsVM> _apiClientGetAllAssignCreditDetails;
		private readonly IApiClient<AssignCreditByRateVM> _apiClientAssignCreditByRate;
		private readonly IApiClient<GetByRateIdForAssignCreditVM> _apiClientGetByRateIdForAssignCredit;
		private readonly IApiClient<AssignCredits> _apiClientAssignCredits;

        public ResellerAssignCreditService(IApiClient<OrganizationAdmin> apiClientOrganizationAdmin, 
            IApiClient<CreditsType> apiClientCreditsType, 
            IApiClient<RateAssignCreditVM> apiClientRateAssignCredit, 
            IApiClient<GetAllAssignCredit> apiClientGetAllAssignCredit, 
            IApiClient<AssignCreditDetailsVM> apiClientGetAllAssignCreditDetails, 
            IApiClient<AssignCreditByRateVM> apiClientAssignCreditByRate,
            IApiClient<GetByRateIdForAssignCreditVM> apiClientGetByRateIdForAssignCredit,
            IApiClient<AssignCredits> apiClientAssignCredits
            )
        {
            _apiClientOrganizationAdmin = apiClientOrganizationAdmin;
            _apiClientCreditsType = apiClientCreditsType;
			_apiClientRateAssignCredit = apiClientRateAssignCredit;
            _apiClientGetAllAssignCredit = apiClientGetAllAssignCredit;
            _apiClientGetAllAssignCreditDetails = apiClientGetAllAssignCreditDetails;
            _apiClientAssignCreditByRate = apiClientAssignCreditByRate;
            _apiClientGetByRateIdForAssignCredit = apiClientGetByRateIdForAssignCredit;
            _apiClientAssignCredits = apiClientAssignCredits;
        }
        //public async Task<AssignCredits> GetAssignCreditsByAssignCreditByRateId(int Id)
        public async Task<IEnumerable<AssignCredits>> GetAssignCreditsByAssignCreditByRateId(int Id)
        {
            var rate = await _apiClientAssignCredits.GetListByIdAsync("ResellerAssignCredit/GetAssignCreditByRateAssignCreditId/" + Id);
            return rate.Data;
        }

        public async Task<GetByRateIdForAssignCreditVM> GetAssignByRateId(int Id)
        {
            var rate = await _apiClientGetByRateIdForAssignCredit.GetByIdAsync("ResellerAssignCredit/GetRateById/" + Id);
            return rate.Data;
        }
        public async Task<IEnumerable<CreditsType>> GetCreditTypeList()
        {
            //_logger.LogInformation("GetAllCountry Service initiated");
            var result = await _apiClientCreditsType.GetAllAsync("ResellerAssignCredit/GetCreditTypeList");
            //_logger.LogInformation("GetAllCountry Service conpleted");
            return result.Data;
        }
        public async Task<int> AddAssignCreditByRate(AssignCreditByRateVM model)
        {
            var users = await _apiClientAssignCreditByRate.PostAsync("ResellerAssignCredit/AddCreditAssignByRate", model);
            return users.Data;
        }


        public async Task<IEnumerable<GetAllAssignCredit>> GetAllAssignCredit()
        {
            //_logger.LogInformation("GetAllCountry Service initiated");
            var result = await _apiClientGetAllAssignCredit.GetAllAsync("ResellerAssignCredit/GetAllAssignCredit");
            //_logger.LogInformation("GetAllCountry Service conpleted");
            return result.Data;
        }

        public async Task<IEnumerable<OrganizationAdmin>> GetOrganizationAdminList()
		{
			//_logger.LogInformation("GetAllCountry Service initiated");
			var result = await _apiClientOrganizationAdmin.GetAllAsync("ResellerAssignCredit/GetOrganizationList");
			//_logger.LogInformation("GetAllCountry Service conpleted");
			return result.Data;
		}
		public async Task<IEnumerable<CreditsType>> GetCreditsTypeList()
		{
			//_logger.LogInformation("GetAllCountry Service initiated");
			var result = await _apiClientCreditsType.GetAllAsync("ResellerAssignCredit/GetCreditList");
			//_logger.LogInformation("GetAllCountry Service conpleted");
			return result.Data;
		}
        public async Task<int> AddRate(RateAssignCreditVM model)
        {
            var users = await _apiClientRateAssignCredit.PostAsync("ResellerAssignCredit/AddRate", model);
            return users.Data;
        }
        public async Task<RateAssignCreditVM> GetRateById(int Id)
        {
            var rate = await _apiClientRateAssignCredit.GetByIdAsync("ResellerAssignCredit/GetRateById/"+Id);
            return rate.Data;
        }

        public async Task<RateAssignCreditVM> EditRate(RateAssignCreditVM model)
        {
            var users = await _apiClientRateAssignCredit.PutAsync("ResellerAssignCredit/EditRate", model);
            return users.Data;
        }

        public async Task<AssignCreditDetailsVM> GetAssignCreditDetails(int id)
        {
            var apiUrl = $"ResellerAssignCredit/GetAssignCreditById/{id}";
            var userData = await _apiClientGetAllAssignCreditDetails.GetByIdAsync(apiUrl);
            return userData.Data;
        }
    }
}
