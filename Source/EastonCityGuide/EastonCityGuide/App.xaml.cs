using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EastonCityGuide.Services;
using EastonCityGuide.Views;
using System.Collections.Generic;

namespace EastonCityGuide
{
    public partial class App : Application
    {
        private static Dictionary<string, string> songs = null;

        public App()
        {
            MainPage = new NavigationPage( new MapPage() );

            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        private static void InitializeSongs()
        {
            songs = new Dictionary<string, string>();
            songs.Add("ArtsTrail", "Rick.mp3");
            songs.Add("CenterSquare", "Rick.mp3");
            songs.Add("Columbus", "Rick.mp3");
            songs.Add("Cottingham", "Rick.mp3");
            songs.Add("CourtHouse", "Rick.mp3");
            songs.Add("EAHS", "Rick.mp3");
            songs.Add("EPBridge", "Rick.mp3");
            songs.Add("LarryHolmes", "Rick.mp3");
            songs.Add("NurtureNature", "Rick.mp3");
            songs.Add("Paxinosa", "Rick.mp3");
            songs.Add("Library", "Rick.mp3");
            songs.Add("Market", "Rick.mp3");
            songs.Add("RiverSide", "Rick.mp3");
            songs.Add("Sigal", "Rick.mp3");
            songs.Add("Thatre", "Rick.mp3");
            songs.Add("Vietnam", "Rick.mp3");
            songs.Add("WAHS", "Rick.mp3");
        }

        public static void Music(string Page)
        {
            if (songs == null)
                InitializeSongs();

            //var page = (Page)Activator.CreateInstance(link.TargetType);

            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;

            if (songs.ContainsKey(Page))
            {
                player.Load(songs[Page]);
                player.Play();
            }
            else
            {
                player.Stop();
            }

            /*
            if (Page.Equals("CenterSquare")){player.Load("Rick.mp3");player.Play();}
            else if (Page.Equals("CenterSquare")) { player.Load("Rick.mp3"); player.Play(); }
            else if (Page.Equals("ArtsTrail"))
            {
                player.Load("Rick.mp3");
                player.Play();
            }
            else if (Page.Equals("Columbus"))
            {
                player.Load("Rick.mp3");
                player.Play();
            }
            else if (Page.Equals("Cottingham"))
            {
                player.Load("Rick.mp3");
                player.Play();
            }
            else if (Page.Equals("CourtHouse"))
            {
                player.Load("Rick.mp3");
                player.Play();
            }
            else if (Page.Equals("EAHS"))
            {
                player.Load("Rick.mp3");
                player.Play();
            }
            else if (Page.Equals("EPBridge"))
            {
                player.Load("Rick.mp3");
                player.Play();
            }
            else if (Page.Equals("LarryHolmes"))
            {
                player.Load("Rick.mp3");
                player.Play();
            }
            else if (Page.Equals("NurtureNature"))
            {
                player.Load("Rick.mp3");
                player.Play();
            }
            else if (Page.Equals("Paxinosa"))
            {
                player.Load("Rick.mp3");
                player.Play();
            }
            else if (Page.Equals("Library"))
            {
                player.Load("Rick.mp3");
                player.Play();
            }
            else if (Page.Equals("Market"))
            {
                player.Load("Rick.mp3");
                player.Play();
            }
            else if (Page.Equals("RiverSide"))
            {
                player.Load("Rick.mp3");
                player.Play();
            }
            else if (Page.Equals("Sigal"))
            {
                player.Load("Rick.mp3");
                player.Play();
            }
            else if (Page.Equals("Theatre"))
            {
                player.Load("Rick.mp3");
                player.Play();
            }
            else if (Page.Equals("Vietnam"))
            {
                player.Load("Rick.mp3");
                player.Play();
            }
            else if (Page.Equals("WilsonHS"))
            {
                player.Load("Rick.mp3");
                player.Play();
            }
            else
            {
                player.Stop();
            }
            */
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
