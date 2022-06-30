using Microsoft.AspNetCore.Mvc;
using WhatIsYourNumber.Services;

namespace WhatIsYourNumber.Controllers
{
    public class YearController : Controller
    {
        private readonly NumbersApiService _numbersApiService;

        public YearController(NumbersApiService numbersApiService)
        {
            _numbersApiService = numbersApiService;
        }
        public async Task<IActionResult> Index(int? year)

        {
            if (year == null)
            {
                var date = DateTime.Today;
                 year = date.Year;
            }
           
            var result = await _numbersApiService.GetNumbersYearResult(year.GetValueOrDefault());
            ViewBag.Result = result;
            return View();
        }

        public IActionResult GetYear()
        {
            return View("NewYear");
        }
        public async Task<IActionResult> NewYear(int? year)
        {
       
           return RedirectToAction("Index",new{year});
        }

        public async Task<IActionResult> RandomYear()
        {
            Random rand = new Random();
            var year = rand.Next(-1000, 2022);
         
            return RedirectToAction("Index", new{year});
        }


    }
}
