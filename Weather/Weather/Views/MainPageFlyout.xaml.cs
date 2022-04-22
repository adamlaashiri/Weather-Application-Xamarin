using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageFlyout : ContentPage
    {
        public ListView ListView;

        public MainPageFlyout()
        {
            InitializeComponent();

            BindingContext = new MainPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class MainPageFlyoutViewModel
        {
            /*  Choosing string as parameter input as the names of various cities will be used to get relevant forecast data
                I could also use enums to assign cities "special ids"
            */
            public ObservableCollection<MainPageFlyoutMenuItem<string>> MenuItems { get; set; }

            public MainPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MainPageFlyoutMenuItem<string>>(new[]
                {
                    new MainPageFlyoutMenuItem<string> { Id = 0, Title = "About Weather", TargetType=typeof(AboutPage) },
                    new MainPageFlyoutMenuItem<string> { Id = 1, Title = "Debug Console", TargetType=typeof(ConsolePage) },
                    new MainPageFlyoutMenuItem<string> { Id = 2, Title = "Uppsala", TargetType=typeof(ForecastPage), Param = "Uppsala" },
                    new MainPageFlyoutMenuItem<string> { Id = 3, Title = "Stockholm", TargetType=typeof(ForecastPage), Param = "Stockholm" },
                    new MainPageFlyoutMenuItem<string> { Id = 4, Title = "Miami", TargetType=typeof(ForecastPage), Param = "Miami"},
                    new MainPageFlyoutMenuItem<string> { Id = 4, Title = "New York", TargetType=typeof(ForecastPage), Param = "New York"},
                    new MainPageFlyoutMenuItem<string> { Id = 4, Title = "Los Angeles", TargetType=typeof(ForecastPage), Param = "Los Angeles"},
                    new MainPageFlyoutMenuItem<string> { Id = 4, Title = "Bombay", TargetType=typeof(ForecastPage), Param = "Bombay"},
                    new MainPageFlyoutMenuItem<string> { Id = 4, Title = "Bangkok", TargetType=typeof(ForecastPage), Param = "Bangkok"},
                });
            }
        }
    }
}