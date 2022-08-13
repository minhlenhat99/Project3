using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientSample
{
    public class PropertyReadDto
    {
        public Guid Id { get; set; }
        public string Info { get; set; }
        //public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        //public Guid BuId { get; set; }
        public string BuName { get; set; }
        public bool IsChecked { get; set; }
    }
    class Program
    {
        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }
        static void Show(IEnumerable<PropertyReadDto> properties)
        {
            foreach (var p in properties)
            {
                Console.WriteLine($"{p.Id} - {p.CategoryName}");
            }
        }
        static async Task<IEnumerable<PropertyReadDto>> GetPropertyAsync()
        {
            IEnumerable<PropertyReadDto> properties = null;
            HttpResponseMessage response = await client.GetAsync($"api/Property");
            if (response.IsSuccessStatusCode)
            {
                properties = await response.Content.ReadAsAsync<IEnumerable<PropertyReadDto>>();
            }
            return properties;
        }
        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://localhost:25002/");
            var properties = await GetPropertyAsync();
            Show(properties);
        }

    }
}
