using MinhMVC;
using Xamarin.Forms;

namespace XamarinClient.Views
{
    public class BaseView<TModel, TView> : ContentPage, IView where TView : View, new()
    {
        protected static NavigationPage _pageContainer;
        protected static NavigationPage PageContainter
        {
            get
            {
                if (_pageContainer == null)
                {
                    _pageContainer = new NavigationPage();
                }
                return _pageContainer;
            }
        }
        protected TView MainContent { get; set; }
        public TModel Model { get; set; }
        public void Render(ControllerContext context)
        {
            Model = (TModel)context.Model;
            MainContent = new TView();
            Content = MainContent;
            RenderCore();
            SetMainPage(this);
        }
        protected virtual void RenderCore()
        {

        }
        protected virtual void SetMainPage(object page)
        {
            MainPage.mainPage.Detail = (Page)page;
            Application.Current.MainPage = MainPage.mainPage;
            //Application.Current.MainPage = (Page)page;
        }
    }
}
