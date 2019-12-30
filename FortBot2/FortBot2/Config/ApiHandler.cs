using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace FortBot2.Config
{
    public class ApiHandler
    {
        public static HttpClient InitClient()
        {
            HttpClient _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("TRN-Api-Key", "9d9ad97a-fca0-45d5-bbbb-59281d815252");

            return _httpClient;
        }
    }
}
