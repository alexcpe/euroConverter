using System.Net.Http.Headers;
using ClientLourd.Models;

namespace ClientLourd.Services
{
    public class DeviseService
    {
        private static readonly Lazy<DeviseService> _instance = new Lazy<DeviseService>(() => new DeviseService());

        public static DeviseService Instance => _instance.Value;

        private readonly HttpClient _client = new HttpClient();

        private DeviseService()
        {
            _client.BaseAddress = new Uri("https://apidevises.azurewebsites.net/api/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Devise>> GetAllDevisesAsync()
        {
            List<Devise> responseBody = null;

            try
            {
                using HttpResponseMessage response = await _client.GetAsync("devises");
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsAsync<List<Devise>>();
                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return responseBody;
        }
    }
}