using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TestDetails
{
    public class BarcodeDetails
    {
       public async Task<IList<stock_export>> GetDetails(string barcode)
        {
             HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var testt = "";
            string username = ConfigurationManager.AppSettings["username"];
            string password = ConfigurationManager.AppSettings["password"];
            string url = ConfigurationManager.AppSettings["url"];
            string companyname = ConfigurationManager.AppSettings["companyname"];
            if (barcode != null)
            {
                testt = barcode;
            }

            var str = "Report/Stock Export?" + string.Format("CompanyName={0}&UserName={1}&password={2}&IBarcode={3}", companyname, username, password, testt);
            client.BaseAddress = new Uri(url);
            var json = "";
            HttpResponseMessage response = await client.GetAsync(str);
            if (response.IsSuccessStatusCode)
            {
                json = await response.Content.ReadAsStringAsync();
            }

            JObject productSearch = JObject.Parse(json);

            // get JSON result objects into a list
            IList<JToken> results = productSearch["stock_export"].Children().ToList();

           // serialize JSON results into .NET objects
            IList<stock_export> searchResults = new List<stock_export>();
            foreach (JToken result in results)
            {
                // JToken.ToObject is a helper method that uses JsonSerializer internally
                stock_export searchResult = result.ToObject<stock_export>();
                searchResults.Add(searchResult);
            }
            return searchResults;
        }
        
    }
}
