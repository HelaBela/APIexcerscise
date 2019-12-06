using System;
using System.Net.Http;
using System.Net.Http.Headers;
using APIwithoutMVC;


namespace Helena
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // the person
            HttpResponseMessage response = client.GetAsync("api/Sumanth").Result;

            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
//                var people = response.Content.ReadAsAsync<APIwithoutMVC.Person>().Result;
               

              Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }
        }
    }
}