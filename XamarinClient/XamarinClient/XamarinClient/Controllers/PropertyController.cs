using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XamarinClient.Models;

namespace XamarinClient.Controllers
{
    public class PropertyController : BaseController
    {
        public object ListProperties()
        {
            var task = Task.Run(() => GetAllProperties());
            var result = task.Result;
            return View(result);
        }
        public object ListProperties(IEnumerable<PropertyReadDto> properties)
        {
            return View(properties);
        }
        public async Task<IEnumerable<PropertyReadDto>> GetAllProperties()
        {
            IEnumerable<PropertyReadDto> properties = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(PROPERTY_URI_PATH);
                if (response.IsSuccessStatusCode)
                {
                    properties = await response.Content.ReadAsAsync<IEnumerable<PropertyReadDto>>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return properties;
        }
        public object FindPropertiesByBuId(Guid buId)
        {
            var task = Task.Run(() => FindPropertiesByBuIdExecution(buId));
            var result = task.Result;
            return RedirectToAction("ListProperties", result);
        }
        public async Task<IEnumerable<PropertyReadDto>> FindPropertiesByBuIdExecution(Guid buId)
        {
            IEnumerable<PropertyReadDto> properties = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync($"{PROPERTY_URI_PATH}/{buId}");
                if (response.IsSuccessStatusCode)
                {
                    properties = await response.Content.ReadAsAsync<IEnumerable<PropertyReadDto>>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return properties;
        }
    }
}
