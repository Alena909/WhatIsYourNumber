using System.Net.Http.Headers;

namespace WhatIsYourNumber.Services
{
    public class NumbersApiService
    {
        private readonly HttpClient _httpClient;

        public NumbersApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://numbersapi.com/");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetNumbersDateResult(int month, int day)
        {
            try
            {
                var requestUrl = $"{month}/{day}/date";
                var result = await _httpClient.GetAsync(requestUrl);
                if (result.IsSuccessStatusCode)
                {
                    var responseString = await result.Content.ReadAsStringAsync();
                    return responseString;
                }
                else
                {
                    return $"Error: {result.StatusCode} {result.ReasonPhrase}";
                }
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
          
        }

        public async Task<string> GetNumbersNumberResult(int number)
        {

            try
            {
                var requestUrl = $"{number}";
                var result = await _httpClient.GetAsync(requestUrl);
                if (result.IsSuccessStatusCode)
                {
                    var responseString = await result.Content.ReadAsStringAsync();
                    return responseString;
                }
                else
                {
                    return $"Error: {result.StatusCode} {result.ReasonPhrase}";
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public async Task<string> GetNumbersYearResult(int year)
        {

            try
            {
                var requestUrl = $"{year}/year";
                var result = await _httpClient.GetAsync(requestUrl);
                if (result.IsSuccessStatusCode)
                {
                    var responseString = await result.Content.ReadAsStringAsync();
                    return responseString;
                }
                else
                {
                    return $"Error: {result.StatusCode} {result.ReasonPhrase}";
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
