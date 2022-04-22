using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Weather.Models;
using Weather.Services;
using Xamarin.Forms;

namespace Weather.ViewModels
{
    public class GroupedForecastViewModel : BaseViewModel

    {
        string _cityName;
        IEnumerable<IGrouping<DateTime, ForecastItem>> _groupedForecast;

        public string CityName
        {
            set => Set<string>(ref _cityName, value, "CityName");
            get => _cityName;
        }

        public IEnumerable<IGrouping<DateTime, ForecastItem>> GroupedForecast
        {
            set => Set<IEnumerable<IGrouping<DateTime, ForecastItem>>>(ref _groupedForecast, value, "GroupedForecast");
            get => _groupedForecast;
        }

        OpenWeatherService _service;

        public GroupedForecastViewModel(OpenWeatherService service)
        {
            _service = service;
        }

        public async Task LoadForecast(ActivityIndicator indicator)
        {
            indicator.IsVisible = true;
            indicator.IsRunning = true;
            //Here you load the forecast
            try
            {
                var result = await _service.GetForecastAsync(_cityName);
                // I don't really see a use for "groupedForecst class" as only the grouped items are necessary, the city name is already present("known") in this instance
                GroupedForecast = null;
                GroupedForecast = result.Items.OrderBy(i => i.DateTime).GroupBy(i => i.DateTime.Date, i => i);
            }
            catch (Exception ex)
            {
                // Could display a modal for error, but that's for second part of this project!
            }

            indicator.IsRunning = false;
            indicator.IsVisible = false;
        }
    }
}
