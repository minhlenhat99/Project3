using MinhMVC;
using System.Net.Http;

namespace XamarinClient.Controllers
{
    public class BaseController : Controller
    {
        protected const string PROPERTY_URI_PATH = "api/Property";
        protected const string BU_URI_PATH = "api/BU";
        protected const string AUTHENTICATION_URI_PATH = "api/Authentication";
        protected const string INVENTORY_URI_PATH = "api/Inventory";

        protected static HttpClient _client = new HttpClient();
    }
}
