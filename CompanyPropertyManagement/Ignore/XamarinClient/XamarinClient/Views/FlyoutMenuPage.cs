using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinUser.Views.User
{
    //Side menu View
    public class FlyoutMenuPage : ContentPage
    {
        // List view chua thong tin cac item cua side menu
        public ListView ListView { get; set; }
        public FlyoutMenuPage()
        {
            var flyoutPageItems = new List<FlyoutPageItem>();
            flyoutPageItems.Add(new FlyoutPageItem { Title = "Thông tin cá nhân", Name = "PersonalInfoUpdate" });
            flyoutPageItems.Add(new FlyoutPageItem { Title = "Thông tin liên hệ", Name = "ContactInfoUpdate" });
            flyoutPageItems.Add(new FlyoutPageItem { Title = "Đổi mật khẩu", Name = "ChangePassword" });
            flyoutPageItems.Add(new FlyoutPageItem { Title = "Quản lý đào tạo" });
            flyoutPageItems.Add(new FlyoutPageItem { Title = "Điểm rèn luyện" });
            flyoutPageItems.Add(new FlyoutPageItem { Title = "Điểm học tập" });
            // Tao content cho ListView
            ListView = new ListView
            {
                ItemsSource = flyoutPageItems,
                ItemTemplate = new DataTemplate(() =>
                {
                    var grid = new Grid { Padding = new Thickness(5, 10) };
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(30) });

                    var label = new Label { VerticalOptions = LayoutOptions.FillAndExpand, TextColor = Color.Black};
                    label.SetBinding(Label.TextProperty, "Title");

                    grid.Children.Add(label, 1, 0);

                    return new ViewCell { View = grid };
                }),
            };
            // Title bat buoc phai co
            Title = "Flyout Page";
            Padding = new Thickness(0, 20, 0, 0);
            // Day la content cua Page 
            Content = new StackLayout
            {
                Children = { ListView }
            };
        }
    }
    class FlyoutPageItem
    {
        public string Title { get; set; }
        public string Name { get; set; }
    }
}
