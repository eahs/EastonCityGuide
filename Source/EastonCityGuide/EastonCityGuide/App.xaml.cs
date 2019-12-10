using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EastonCityGuide.Services;
using EastonCityGuide.Views;

namespace EastonCityGuide
{
    public partial class App : Application
    {

        public App()
        {
            MainPage = new NavigationPage( new MapPage() );

            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
