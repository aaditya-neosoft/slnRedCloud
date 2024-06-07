﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RedCloud.Application.Features.AssignmentType;
using RedCloud.Application.Features.Campaign;
using RedCloud.Application.Features.Numbers.Commands;
using RedCloud.Application.Features.ResellerAdminuser.Queries;
using RedCloud.Domain.Entities;
using RedCloud.Interfaces;
using RedCloud.Services;
using RedCloud.ViewModel;
using System.ComponentModel.Design;

namespace RedCloud.Controllers
{
    public class NumberController : Controller
    {
        private readonly IDropDownService<CountryVM> _dropDownService;
        private readonly IStateService<StateVM> _stateService;
        private readonly ICarrier<CarrierVM> _carrier;
        private readonly IType<TypesVM> _type;
        private readonly INumberService<NumberVM> _numberService;
        private readonly IAssignmentType<AssignmentTypeVM> _assignmentType;
        private readonly IAdminResellerUser _adminResellerUser;
        private readonly IOrganizationAdminService _organizationAdminService;//take getall from aakash 
        private readonly ICampaign<CampaignVM> _campaign;



        public NumberController(IDropDownService<CountryVM> dropDownService, IOrganizationAdminService organizationAdminService,ICampaign<CampaignVM> campaign, IAdminResellerUser adminResellerUser, IStateService<StateVM> stateService, ICarrier<CarrierVM> carrier, IType<TypesVM> type, INumberService<NumberVM> numberService, IAssignmentType<AssignmentTypeVM> assignmentType)
        {
            _dropDownService = dropDownService;
            _stateService = stateService;
            _carrier = carrier;
            _type = type;
            _numberService = numberService;
            _assignmentType = assignmentType;
            _adminResellerUser = adminResellerUser;
            _organizationAdminService = organizationAdminService;
            _campaign = campaign;

        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddNumber()

        {
            var carrierlist = await _carrier.GetAllCarriersList();
            ViewBag.AdminList = new SelectList(carrierlist, "CarrierId", "CarrierName");
            var countries = await _dropDownService.GetAllCountryList();
            ViewBag.Country = countries;
            var typelist = await _type.GetAllTypesList();
            ViewBag.Typelist = new SelectList(typelist, "TypesId", "TypesName");

            return View(new NumberVM());
        }

        [HttpPost]
        public async Task<IActionResult> AddNumber(NumberVM Model)
        {

            var response = await _numberService.AddNumber(Model);//name of service and service method

            return RedirectToAction("AddNumber");
        }

        public async Task<IActionResult> AssignNumber(int Id)
        {


            var response = await _numberService.GetNumberById(Id);
            var resellerList = await _adminResellerUser.GetallResellerAdmin();
            ViewBag.ResellerList = new SelectList(resellerList, "ResellerAdminUserId", "ResellerName");
            var campaignlist = await _campaign.GetallCampaignlist();
            ViewBag.Campaignlist = new SelectList(campaignlist, "CampaignId", "CampaignId");
            var assignmenttype = await _assignmentType.Getallassignments();
            ViewBag.Assignmenttype = new SelectList(assignmenttype, "AssignmentTypeId", "AssignmentTypeName");
            var orgadmin = await _organizationAdminService.GetAllOrganizationAdmin();
            ViewBag.Orgadmin = new SelectList(orgadmin, "OrgID", "OrgName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> AssignNumber(AssignNumberViewModel request)
        {
            var response = _numberService.UpdateNumber(request);
            return RedirectToAction("AddNumber");
        }

    }
}
