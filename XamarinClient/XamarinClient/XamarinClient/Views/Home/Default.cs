using MinhMVC;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XamarinClient.Views.Home
{
    public class Default : BaseView<object, StackLayout>
    {
        protected override void RenderCore()
        {
            Padding = new Thickness(20, 0, 10, 0);

            var listView = new ListView();
            listView.ItemsSource = new List<string> 
            {
                "Property Tracking",
                "Property Inventories"
            };
            listView.ItemTemplate = new DataTemplate(() =>
            {
                Label option = new Label
                {
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
                    TextColor = Color.Black
                };
                option.SetBinding(Label.TextProperty, ".");
                ViewCell viewCell = new ViewCell
                {
                    View = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        Children =
                        {
                            new StackLayout
                            {
                                Children =
                                {
                                    option
                                }
                            }
                        }
                    }
                };
                return viewCell;
            });
            listView.ItemSelected += (s, e) =>
            {
                switch (e.SelectedItemIndex)
                {
                    case 0:
                        Engine.Execute("BU/ListBus");
                        break;
                    case 1:
                        break;
                }
                listView.SelectedItem = null;

            };

            MainContent.Children.Add(listView);
        }
        protected override void SetMainPage(object page)
        {
            _pageContainer = null;
            PageContainter.PushAsync(this);
            base.SetMainPage(PageContainter);
        }
    }
}
