using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Invoice.Begin.People;

//For fun
namespace Invoice.Begin.Union
{
    public class CountryInfoProvider : ICountryInfoProvider
    {
        const string URL = "https://restcountries.eu";
        string URLParameter = "/rest/v2/regionalbloc/eu";


        public bool IsInEurope(Country country) {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(URL + URLParameter).Result;
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<CountryObj>>().Result;
                foreach (var d in dataObjects)
                {
                    if (d.alpha2Code == country.Code || d.alpha3Code == country.Code)
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
