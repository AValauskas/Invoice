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


        public bool IsEurope(Provider provider) {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            client.DefaultRequestHeaders.Accept.Add(
           new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(URL + URLParameter).Result;
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<Object>>().Result;
                foreach (var d in dataObjects)
                {
                    if (d.alpha2Code == provider.GetCountry().GetName() || d.alpha3Code == provider.GetCountry().GetName())
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

        public bool IsEurope(Customer customer)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            client.DefaultRequestHeaders.Accept.Add(
           new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(URL + URLParameter).Result;
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<Object>>().Result;
                foreach (var d in dataObjects)
                {
                    if (d.alpha2Code == customer.GetCountry().GetName() || d.alpha3Code == customer.GetCountry().GetName())
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
