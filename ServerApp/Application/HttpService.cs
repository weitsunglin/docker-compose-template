using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyApp.Services
{
    public class HttpService
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        public async Task<string> SendRequestAsync(string url)
        {
            Console.WriteLine("Sending HTTP request...");
            var response = await HttpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"HTTP response: {responseBody}");
                return responseBody;
            }
            else
            {
                Console.WriteLine($"HTTP request failed with status code: {response.StatusCode}");
                return null;
            }
        }
    }
}