using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XamarinClient.Models;

namespace XamarinClient.Controllers
{
    public class BUController : BaseController
    {
        public object ListBus()
        {
            var task = Task.Run(() => GetAllBus());
            var result = task.Result;
            return View(result);
        }
        public object ListBus(IEnumerable<BUReadDto> Bus)
        {
            return View(Bus);
        }
        public async Task<IEnumerable<BUReadDto>> GetAllBus()
        {
            IEnumerable<BUReadDto> Bus = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(BU_URI_PATH);
                if (response.IsSuccessStatusCode)
                {
                    Bus = await response.Content.ReadAsAsync<IEnumerable<BUReadDto>>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Bus;
        }
    }
}
