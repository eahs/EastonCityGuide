using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace EastonCityGuide.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://www.easton-pa.com/")));
        }

        public ICommand OpenWebCommand { get; }
    }
}