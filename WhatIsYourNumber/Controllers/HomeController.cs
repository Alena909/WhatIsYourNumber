using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WhatIsYourNumber.Models;
using WhatIsYourNumber.Services;

namespace WhatIsYourNumber.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NumbersApiService _numbersApiService;

        public HomeController(ILogger<HomeController> logger, NumbersApiService numbersApiService)
        {
            _logger = logger;
            _numbersApiService = numbersApiService;
        }



        public async Task<IActionResult> Index(int? month, int? day)

        {
           if (month == null || day == null)
           {
               var date = DateTime.Now;
               day = date.Day;
               month = date.Month;
           } 
            
           var factMonthDay = await _numbersApiService.GetNumbersDateResult(month.GetValueOrDefault(), day.GetValueOrDefault());

         
           ViewBag.MonthDay = factMonthDay;
         
           return View();
        }

        
        public IActionResult Dates()
        {
            return RedirectToAction("Index","Date");
        }

     
    }
}