using MinhMVC;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using XamarinClient.Models;

namespace XamarinClient.Controllers
{
    public class InventoryController : BaseController
    {
        public object CreateInventory(InventoryCreateDto inventoryCreateDto)
        {
            var myContent = JsonConvert.SerializeObject(inventoryCreateDto);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var task = Task.Run(() => CreateInventoryExecution(byteContent));
            var result = task.Result;
            Task.WaitAll();
            if (result.ToLower().Equals("created"))
            {
                _ = Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Alert", "Success", "OK");
            }
            else
            {
                _ = Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Alert", "Failed", "OK");
            }
            return null;
        }
        public async Task<string> CreateInventoryExecution(HttpContent content)
        {
            var response = string.Empty;
            try
            {
                HttpResponseMessage result = await _client.PostAsync(INVENTORY_URI_PATH, content);
                if (result.IsSuccessStatusCode)
                {
                    response = result.StatusCode.ToString();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return response;
        }
    }
}
