using MinhMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using XamarinClient.Models;
using XamarinClient.Views.Home;
using ZXing.Net.Mobile.Forms;

namespace XamarinClient.Views.Property
{
    internal class ListProperties : BaseView<IEnumerable<PropertyReadDto>, StackLayout>
    {
        protected override void RenderCore()
        {
            Padding = new Thickness(5, 0, 10, 0);

            var buId = Model.ToList()[0].BuId;
            var groupSeatCodes = Model.GroupBy(p => p.SeatCode).OrderBy(i => i.Key);

            //Model.First().IsChecked = true;

            var listView = new ListView();
            listView.IsGroupingEnabled = true;
            listView.ItemsSource = groupSeatCodes;
            listView.GroupHeaderTemplate = new DataTemplate(() =>
            {
                var header = new Label()
                {
                    Padding = new Thickness(15, 0, 0, 0),
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
                    TextColor = Color.Black,
                    FontAttributes = FontAttributes.Bold,
                    VerticalTextAlignment = TextAlignment.Center,
                };
                header.SetBinding(Label.TextProperty, "Key");
                return new ViewCell
                {
                    View = header
                };
            });
            listView.ItemTemplate = new DataTemplate(() =>
            {
                Image icon = new Image
                {
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.EndAndExpand,
                    //Source = "Chair.jpg"
                };
                icon.SetBinding(Image.SourceProperty, "ImageSource");

                Label category = new Label
                {
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    FontSize = 12,
                };
                category.SetBinding(Label.TextProperty, "CategoryName");
                
                CheckBox checkBox = new CheckBox
                {
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand
                };
                checkBox.IsEnabled = false;
                checkBox.SetBinding(CheckBox.IsCheckedProperty, "IsChecked");

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
                                Orientation = StackOrientation.Vertical,
                                VerticalOptions = LayoutOptions.FillAndExpand,
                                HorizontalOptions = LayoutOptions.Start,
                                Spacing = 2,
                                //BackgroundColor = Color.FromRgb(36,96,173),
                                WidthRequest = 70,
                                Children =
                                {
                                    icon
                                }
                            },
                            new StackLayout
                            {
                                WidthRequest = 250,
                                Spacing = 3,
                                Children =
                                {
                                    category
                                }
                            },
                            new StackLayout
                            {
                                HorizontalOptions = LayoutOptions.End,
                                Children =
                                {
                                    checkBox
                                }
                            }
                        }
                    }
                };
                return viewCell;
            });
            listView.ItemSelected += async (s, e) =>
            {
                var item = e.SelectedItem as PropertyReadDto;
                if (item != null)
                {
                    var scan = new ZXingScannerPage();
                    await PageContainter.PushAsync(scan);

                    scan.OnScanResult += (result) =>
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            await PageContainter.PopAsync();
                            if (result.Text.Equals(item.Id))
                            {
                                Model.SingleOrDefault(p => p.Id.Equals(item.Id)).IsChecked = true; ;
                                Engine.Execute("Property/ListProperties", Model);
                            }
                        });
                    };
                }

                listView.SelectedItem = null;

            };

            var submitBtn = new Button
            {
                Text = "Submit",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            submitBtn.Clicked += (s, e) =>
            {
                if (buId != null)
                {
                    var inventory = new InventoryCreateDto();
                    inventory.BuId = buId;
                    inventory.CheckDate = System.DateTime.Now;
                    inventory.UserId = Guid.Parse("F7B4C721-55DD-4603-216F-08DA7C9DB201");
                    string report = "";
                    foreach (var seatCode in groupSeatCodes)
                    {
                        report += seatCode.Key;
                        report += "\n";
                        foreach (var property in seatCode)
                        {
                            report += "\t";
                            report += property.CategoryName;
                            if (property.IsChecked)
                            {
                                report += "\t";
                                report += "Checked";
                            }
                            report += "\n";
                        }
                        report += "\n";
                    }
                    inventory.Report = report;
                    Engine.Execute("Inventory/CreateInventory", inventory);
                }
            };
            var cancelBtn = new Button
            {
                Text = "Cancel",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            cancelBtn.Clicked += (s, e) =>
            {
                Engine.Execute("BU/ListBus");
            };
            var buttons = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Spacing = 20,
                Children =
                {
                    submitBtn,
                    cancelBtn
                }
            };

            MainContent.Children.Add(listView);
            MainContent.Children.Add(buttons);
        }
        protected override void SetMainPage(object page)
        {
            Default.PageContainter.PushAsync(this);
            base.SetMainPage(Default.PageContainter);
        }
    }
    

}
