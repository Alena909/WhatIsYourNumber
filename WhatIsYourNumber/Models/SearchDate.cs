using System.ComponentModel.DataAnnotations;

namespace WhatIsYourNumber.Models
{
    public class SearchDate
    {
        [Required(ErrorMessage = "Please select a month.")]
        [Range(1,12,ErrorMessage = "Month must be between 1 and 12.")]
        public int? Month { get; set; }

        [Required(ErrorMessage = "Please select a date")]
        [Range(1,31,ErrorMessage = "Date must be between 1 and 31.")]
        public int? Day { get; set; }

        [Required(ErrorMessage = "Please select a year.")]
        public int? Year { get; set; }

        [Required(ErrorMessage = "Please enter a number.")]
        public int? Number { get; set; }

        public MonthEnum MonthOption { get; set; }

       public enum MonthEnum
        {
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12
        }

    }
}
