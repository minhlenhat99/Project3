using MinhMVC;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace XamarinClient.Views
{
    class MainPage : FlyoutPage
    {
        internal static MainPage mainPage = new MainPage();
        FlyoutMenuPage flyoutPage;
        public MainPage()
        {
            flyoutPage = new FlyoutMenuPage();
            this.Flyout = flyoutPage;
            flyoutPage.ListView.ItemSelected += (s, e) =>
            {
                var item = e.SelectedItem as FlyoutPageItem;
                if (item != null)
                {
                    Engine.Execute("User/" + item.Name);
                    flyoutPage.ListView.SelectedItem = null;
                    this.IsPresented = false;
                }
            };
        }
        
    }
    class Grouping<K, T> : ObservableCollection<T>
    {
        //This is the GroupDisplayBinding above for displaying the header
        public K GroupKey { get; private set; }

        public Grouping(K key, IEnumerable<T> items)
        {
            GroupKey = key;
            foreach (var item in items)
                this.Items.Add(item);
        }
    }
}
