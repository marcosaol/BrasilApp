using BrasilApp.Models;
using BrasilApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BrasilApp.ViewModels
{
    public partial class LocateCitysViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<City>? _citys;

        [ObservableProperty] private string _cityName;

        public ICommand getCitysCommand { get; set; }

        public LocateCitysViewModel()
        {
            getCitysCommand = new Command(getCitys);
        }

        public async void getCitys()
        {
            LocateCityService locateCityService = new();
            Citys = await locateCityService.FetchCitys(CityName);
        }

    }
}
