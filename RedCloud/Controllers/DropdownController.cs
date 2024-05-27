﻿using Microsoft.AspNetCore.Mvc;
using RedCloud.Interface;
using RedCloud.Models;

namespace RedCloud.Controllers
{
    public class DropdownController : Controller
    {

        private readonly ILogger<DropdownController> _logger;
        private readonly IDropDownService<CountryVM> _dropDownService;
        private readonly IStateService<StateVM> _stateService;
        private readonly ICityService<CityVM> _cityService;
        public DropdownController(ILogger<DropdownController> logger, IDropDownService<CountryVM> dropDownService, IStateService<StateVM> stateService, ICityService<CityVM> cityService)
        {
            _logger = logger;
            _dropDownService = dropDownService;
            _stateService = stateService;
            _cityService = cityService;
        }
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> GetCountry()
        {

            //    var countries = new List<CountryVM>
            //{
            //   new CountryVM { CountryId = 2, Name = "India" },
            //   new CountryVM { CountryId = 3, Name = "Korea" }

            //};
            //    ViewBag.Country = countries;
            // Log the initiation of the GetCountry method
            _logger.LogInformation("GetCountry method initiated");

            // Fetch the list of countries asynchronously
            var countries = await _dropDownService.GetAllCountryList();

            // Log the completion of the GetCountry method
            _logger.LogInformation("GetCountry method completed");

            // Pass the fetched countries to the view via ViewBag
            ViewBag.Country = countries;

            // Return the view
            return View();

        }




        public async Task<IActionResult> GetStateByCountryId(int countryId)
        {


            _logger.LogInformation("GetStateByCountryId initiated");

            // Call the service method to fetch states based on country ID
            var states = await _stateService.GetStatesByCountryId(countryId);

            _logger.LogInformation("GetStateByCountryId completed");

            // Check if states data is not null and return the partial view

            return PartialView("_StateDropdown", states);



        }





        public async Task<IActionResult> GetCityByStateId(int stateId)
        {

            var city = await _cityService.GetCityByStateId(stateId);
            //List<CityVM> city = new List<CityVM>
            //{
            //new CityVM {StateId=1, CityId = 2, Name = "Mumbai" },
            //new CityVM {StateId=4, CityId = 3, Name = "Hamnisa" }
            //};
           // city = city.Where(x => x.StateId == stateId).ToList();
            return PartialView("_CityDropdown", city);
        }


    }
}
