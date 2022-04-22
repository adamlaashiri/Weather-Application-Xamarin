using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Weather.Models;
using Weather.ViewModels;
using Weather.Services;

namespace Weather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class ForecastPage : ContentPage
    {
        GroupedForecastViewModel viewModel => BindingContext as GroupedForecastViewModel;

        public ForecastPage()
        {
            InitializeComponent();
            // Using viewModel for separation of concern
            BindingContext = new GroupedForecastViewModel(new OpenWeatherService());
        }

        public ForecastPage(string cityName) : this()
        {
            viewModel.CityName = cityName;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Code here will run right before the screen appears
            //You want to set the Title or set the City
            Title = $"Forecast for {viewModel.CityName}";

            //This is making the first load of data
            MainThread.BeginInvokeOnMainThread(async () => {await viewModel.LoadForecast(ActivityIndicator);});
        }
        
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await viewModel.LoadForecast(ActivityIndicator);
        }
    }
}