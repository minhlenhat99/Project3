using MinhMVC;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using XamarinClient.Models;
using XamarinClient.Views.Home;

namespace XamarinClient.Views.BU
{
    internal class ListBus : BaseView<IEnumerable<BUReadDto>, StackLayout>
    {
        protected override void RenderCore()
        {
            Padding = new Thickness(20, 0, 10, 0);

            var listView = new ListView();
            Model = Model.OrderBy(bu => bu.Name);
            listView.ItemsSource = Model;
            listView.ItemTemplate = new DataTemplate(() =>
            {
                Label bu = new Label
                {
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
                    TextColor = Color.Black
                };
                bu.SetBinding(Label.TextProperty, "Name");

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
                                    bu
                                }
                            }
                        }
                    }
                };
                return viewCell;
            });
            listView.ItemSelected += (s, e) =>
            {
                var item = e.SelectedItem as BUReadDto;
                if (item != null)
                {
                    Engine.Execute("Property/FindPropertiesByBuId", item.Id);
                }

                listView.SelectedItem = null;

            };

            MainContent.Children.Add(listView);
        }
        protected override void SetMainPage(object page)
        {
            Default.PageContainter.PushAsync(this);
            base.SetMainPage(Default.PageContainter);
        }
    }
}
