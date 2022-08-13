using MinhMVC;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XamarinClient.Models;

namespace XamarinClient.Controllers
{
    public class BaseController<T> : Controller where T : class
    {
        static HttpClient _client = new HttpClient();
        const string PROPERTY_URI_PATH = "$api/Property";

        static async Task<IEnumerable<PropertyReadDto>> GetPropertyAsync(string path)
        {
            IEnumerable<PropertyReadDto> properties = null;
            HttpResponseMessage response = await _client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                properties = await response.Content.ReadAsAsync<IEnumerable<PropertyReadDto>>();
            }
            return properties;
        }
    }
}
