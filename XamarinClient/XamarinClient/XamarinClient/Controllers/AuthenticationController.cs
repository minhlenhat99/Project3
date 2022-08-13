using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinClient.Models;

namespace XamarinClient.Controllers
{
    public class AuthenticationController : BaseController
    {
        public object Login()
        {
            return View();
        }
        public object Login(UserForAuthenticationDto model)
        {
            var task = Task.Run(() => Authenticate(model));
            var response = task.Result;
            if (response.IsSuccess)
            {
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(response.Data);
                string jsonSave = JsonConvert.SerializeObject(token);
                //HttpContext.Session.SetString("keyvalue", jsonSave);

                return RedirectToAction("Home", "Default");
            }
            return null;
        }
        public async Task<Response<string>> Authenticate(UserForAuthenticationDto model)
        {
            var text = new Response<string>();
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            using (var response = await _client.PostAsync($"{AUTHENTICATION_URI_PATH}/login", content))
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                text = JsonConvert.DeserializeObject<Response<string>>(apiResponse);
            }
            return text;
        }
    }
    public class Response<T>
    {
        public Response()
        {
        }

        public Response(bool isSuccess, HttpStatusCode statusCode, string message, T data)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

        public bool IsSuccess { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
