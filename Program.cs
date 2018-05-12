using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace consume_json_api
{
    class Program
    {
        static void Main(string[] args)
        {
            string resourceUrl = "http://idx.co.id/umbraco/Surface/Home/GetRelistingData?resultCount=7";
            System.Console.WriteLine("HttpClient --->");
            SerializeHttpClient(resourceUrl);

            System.Console.WriteLine("RestSharp --->");
            SerializeRestSharp(resourceUrl);
            Console.ReadKey();

        }
        static void SerializeRestSharp(string resourceUrl)
        {
            var client = new RestClient("https://www.idx.co.id");
            client.AddDefaultHeader(HttpRequestHeader.ContentType.ToString(), "application/json");
            var req = new RestRequest(resourceUrl, Method.GET);
            var res = client.ExecuteAsGet(req, Method.GET.ToString());//, res =>
            if (res.IsSuccessful)
            {
                var listingdata = JsonConvert.DeserializeObject<ListingData>((string)JToken.Parse(res.Content));
                System.Console.WriteLine("{0}-{1}", listingdata.Activities[0].KodeEmiten, listingdata.Activities[0].NamaEmiten);
            }
            else
                System.Console.WriteLine(res.StatusCode);
        }
        static void SerializeHttpClient(string resourceUrl)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://www.idx.co.id");
            client.DefaultRequestHeaders.Add(HttpRequestHeader.ContentType.ToString(), "application/json");
            var task = client.GetAsync(resourceUrl);
            task.Wait();
            var response = task.Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var reader = response.Content.ReadAsStringAsync();
                string result = reader.Result;
                reader.Wait();
                JToken obj = JToken.Parse(result);
                System.Console.WriteLine(obj.ToString());
                var listingdata = JsonConvert.DeserializeObject<ListingData>((string)obj);
                System.Console.WriteLine("{0}-{1}", listingdata.Activities[0].KodeEmiten, listingdata.Activities[0].NamaEmiten);
            }
            else
                System.Console.WriteLine(response.StatusCode);
        }
    }
}
