using Microsoft.AspNetCore.Mvc;
using WhatIsYourNumber.Services;

namespace WhatIsYourNumber.Controllers
{
    public class DateController : Controller

    {
        
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Random()
        {
            Random rand = new Random();
            var month = rand.Next(1, 13);
            int maxDays;
            if (month == 2)
            {
                maxDays = 28;
            }
            else if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                maxDays = 30;
            } else
            {
                maxDays = 31;
            }
            var day = rand.Next(1, maxDays + 1);
          
            return RedirectToAction("Index", "Home",new{month,day});
        }

       }
}
