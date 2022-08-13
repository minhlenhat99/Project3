using MinhMVC;
using System;

namespace XamarinClient.Controllers
{
    public class HomeController : BaseController
    {
        public object Default()
        {
            _client.BaseAddress = new Uri("http://10.0.2.2:25002/");
            //_client.BaseAddress = new Uri("https://localhost:25002/");
            return View();
        }
    }
}
