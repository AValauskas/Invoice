using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Invoice.Begin.People;


namespace Invoice.Begin.Union
{
    public class CountryInfoProvider: ICountryInfoProvider
    {
        const string URL = "https://restcountries.eu";
        string URLParameter = "/rest/v2/regionalbloc/eu";
        public bool IsEurope(string country) {
            
            //calculate calculate
            //this is just for a logic for unit testting
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            client.DefaultRequestHeaders.Accept.Add(
           new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(URL+URLParameter).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<Object>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                foreach (var d in dataObjects)
                {
                    if (d.alpha2Code==country || d.alpha3Code == country )
                    {
                        return true;
                    }
                }
                
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            


            return false;
        }
    }
}
