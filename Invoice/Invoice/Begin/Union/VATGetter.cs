using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Invoice.Begin.People;
using Nancy.Json;
using Newtonsoft.Json;

namespace Invoice.Begin.Union
{
    public class VATGetter : IVatGetter
    {
        const string URL = "https://euvat.ga";
        string URLParameter = "/rates.json";

        public int GetVAT(Country country)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);           
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(URL + URLParameter).Result;

            //Checks from API only countries which are in european union
            if (response.IsSuccessStatusCode)
            {         
                var dataObjects = response.Content.ReadAsAsync<RootObject>().Result;
               foreach (KeyValuePair<string, Rates> item in dataObjects.rates)
                {
                    if (country.Code== item.Key)
                    {
                        return  Convert.ToInt32(Convert.ToDouble(item.Value.standard_rate));
                    }
                }
            }

            //Checks our json file which we can easily edit
            using (StreamReader r = new StreamReader(Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..\\")) + @"/Invoice/ClientJsonFile/ClientCountryesList.json"))
            {

                string json = r.ReadToEnd();
                RootObject items = JsonConvert.DeserializeObject<RootObject>(json);
                foreach (KeyValuePair<string, Rates> item in items.rates)
                {
                    if (country.Code == item.Key)
                    {
                        return Convert.ToInt32(Convert.ToDouble(item.Value.standard_rate));
                    }
                }
            }
          
                throw new BussinessException("VAT were not found, edit your Country VAT list");

            
            
        }

    }
}
