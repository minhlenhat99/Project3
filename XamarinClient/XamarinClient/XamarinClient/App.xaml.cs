using MinhMVC;
using Xamarin.Forms;

namespace XamarinClient
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            Engine.Register(this);
            Engine.Execute("Home/Default");
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
