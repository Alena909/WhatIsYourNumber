using Microsoft.AspNetCore.Mvc;
using WhatIsYourNumber.Services;

namespace WhatIsYourNumber.Controllers
{
    public class NumberController : Controller

    {
        private readonly NumbersApiService _numbersApiService;

        public NumberController(NumbersApiService numbersApiService)
        {
            _numbersApiService= numbersApiService;
        }
        public async  Task<IActionResult> Index(int? number)
        {
            if (number == null)
            {
                 number = 7;
            }
           
            var result = await _numbersApiService.GetNumbersNumberResult(number.GetValueOrDefault());
            ViewBag.Result = result;
            return View();
        }

        public IActionResult NewNumber()
        {
            return View("NewNumber");
        }
      
        public async Task<IActionResult> NewResult(int? number)
        {
       
            return RedirectToAction("Index",new{number});
        }

        public async Task<IActionResult> Random()
        {
            Random rand = new Random();
            var number = rand.Next(1, 100);
       
            return RedirectToAction("Index",new{number});
        }
    }
}
