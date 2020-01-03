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

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://www.seriouseats.com/2012/03/weirdest-ramen-strangest-funniest-gross-packaged-noodles.html")));
        }

        public ICommand OpenWebCommand { get; }
    }
}