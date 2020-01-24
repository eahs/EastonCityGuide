using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EastonCityGuide.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using EastonCityGuide.Services;

namespace EastonCityGuide.Views
{
    public partial class MapPage : ContentPage
    {

        List<string> places = DataService.Places;
        List<Position> locations = DataService.Locations;

        
        readonly Map map;

        public MapPage()
        {

        var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;

            var map = new Map(
                MapSpan.FromCenterAndRadius(
                        new Position(40, -75), Distance.FromMiles(0.3)))
            {
                IsVisible = true,
                IsEnabled = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
                
            };
            map.MoveToRegion(new MapSpan(new Position(40.691216, -75.209130), 0.01, 0.01));

            StackLayout slMap = new StackLayout
            {
                Children = { map },
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(10, 10, 10, 10)
            };
            map.MapType = MapType.Street;

            Slider slider = new Slider(1, 18, 1);
            slider.ValueChanged += (sender, e) =>
            {
                var zoomLevel = e.NewValue; // between 1 and 18
                var latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
                map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongdegrees, latlongdegrees));
            };

            var pin1  = new GuidePin(new Position(40.691216, -75.209130), "Center Square", "Historical Location"                  );
            var pin2  = new GuidePin(new Position(40.691389, -75.212500), "State Theater", "Entertainment"                        );
            var pin3  = new GuidePin(new Position(40.691944, -75.213611), "Easton Public Library", "Educational Facility"         );
            var pin4  = new GuidePin(new Position(40.687306, -75.217623), "NorthHampton County Court House", "Historical Location");
            var pin5  = new GuidePin(new Position(40.691281, -75.210421), "Easton Public Market", "Consumer"                      );
            var pin6  = new GuidePin(new Position(40.690848, -75.210674), "Sigal Museum", "Educational Location"                  );
            var pin7  = new GuidePin(new Position(40.694538, -75.203715), "Easton-Pburg Bridge", "Historical Location"            );
            var pin8  = new GuidePin(new Position(40.692109, -75.205205), "Christopher Columbus Statue", "Historical Location"    );
            var pin9  = new GuidePin(new Position(40.690585, -75.213675), "Nurture Nature Center", "Educational Facility"         );
            var pin10 = new GuidePin(new Position(40.692191, -75.205048), "RiverSide Park", "Recreation"                          );
            var pin11 = new GuidePin(new Position(40.689864, -75.205397), "Larry Holmes Statue", "Historical Location"            );
            var pin12 = new GuidePin(new Position(40.682571, -75.252674), "Easton Area High School", "Educational Facility"       );
            var pin13 = new GuidePin(new Position(40.682574, -75.250029), "Vietnam Memorial", "Historical Location"               );
            var pin14 = new GuidePin(new Position(40.696192, -75.228143), "Karl Stirner Arts Trail", "Entertainment"              );
            var pin15 = new GuidePin(new Position(40.691737, -75.225713), "Cottingham Stadium", "Historical Location"             );
            var pin16 = new GuidePin(new Position(40.690811, -75.227308), "Paxinosa Elementary School", "Educational Facility"    );
            var pin17 = new GuidePin(new Position(40.684204, -75.243630), "Wilson Area High School", "Educational Facility"       );

            pin1.Clicked  += (sender, e) => {Navigation.PushAsync(new PinPages.CenterSquare        ());};
            pin2.Clicked  += (sender, e) => {Navigation.PushAsync(new PinPages.StateTheatre        ());};
            pin3.Clicked  += (sender, e) => {Navigation.PushAsync(new PinPages.PublicLibrary       ());};
            pin4.Clicked  += (sender, e) => {Navigation.PushAsync(new PinPages.CourtHouse          ());};
            pin5.Clicked  += (sender, e) => {Navigation.PushAsync(new PinPages.PublicMarket        ());};
            pin6.Clicked  += (sender, e) => {Navigation.PushAsync(new PinPages.SigalMuseum         ());};
            pin7.Clicked  += (sender, e) => {Navigation.PushAsync(new PinPages.EPBridge            ());};
            pin8.Clicked  += (sender, e) => {Navigation.PushAsync(new PinPages.Columbus            ());};
            pin9.Clicked  += (sender, e) => {Navigation.PushAsync(new PinPages.NurtureNature       ());};
            pin10.Clicked += (sender, e) => {Navigation.PushAsync(new PinPages.RiverSide           ());};
            pin11.Clicked += (sender, e) => {Navigation.PushAsync(new PinPages.LarryHolmes         ());};
            pin12.Clicked += (sender, e) => {Navigation.PushAsync(new PinPages.EastonAreaHighSchool());};
            pin13.Clicked += (sender, e) => {Navigation.PushAsync(new PinPages.VietnamMemorial     ());};
            pin14.Clicked += (sender, e) => {Navigation.PushAsync(new PinPages.ArtsTrail           ());};
            pin15.Clicked += (sender, e) => {Navigation.PushAsync(new PinPages.Cottingham          ());};
            pin16.Clicked += (sender, e) => {Navigation.PushAsync(new PinPages.Paxinosa            ());};
            pin17.Clicked += (sender, e) => {Navigation.PushAsync(new PinPages.WilsonAreaHighSchool());};

            map.Pins.Add(pin1 );
            map.Pins.Add(pin2 );
            map.Pins.Add(pin3 );
            map.Pins.Add(pin4 );
            map.Pins.Add(pin5 );
            map.Pins.Add(pin6 );
            map.Pins.Add(pin7 );
            map.Pins.Add(pin8 );
            map.Pins.Add(pin9 );
            map.Pins.Add(pin10);
            map.Pins.Add(pin11);
            map.Pins.Add(pin12);
            map.Pins.Add(pin13);
            map.Pins.Add(pin14);
            map.Pins.Add(pin15);
            map.Pins.Add(pin16);
            map.Pins.Add(pin17);

            SearchBar searchBar = new SearchBar
            {
                Placeholder = "Search Items...",
                PlaceholderColor = Color.Gray,
                TextColor = Color.Gray,
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(SearchBar)),
                FontAttributes = FontAttributes.None
            };

            Button button = new Button
            {
                Text = "Routing",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Fill,
                BackgroundColor = Color.OrangeRed,
                FontAttributes = FontAttributes.Bold,
                FontSize = 18,
            };
            
            button.Clicked += (sender, args) =>
            {
                 button = (Button)sender;
                 Navigation.PushAsync(new RoutingPage());
            };

            ListView searchResults = new ListView
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill
            };

            void OnTextChanged(object sender, EventArgs e)
            {
                searchBar = (SearchBar)sender;
                searchResults.ItemsSource = DataService.GetSearchResults(searchBar.Text);
            }

            void OnSearchButtonPressed(object sender, EventArgs e)
            {
                searchBar = (SearchBar)sender;
                searchResults.ItemsSource = DataService.GetSearchResults(searchBar.Text);

                for (int i = 0; i < places.Count; i++)
                {
                    if (searchBar.Text.ToLower().Equals(places[i].ToLower()))
                    {
                        map.MoveToRegion(new MapSpan(locations[i], 0.001, 0.001));
                    }
                }
            }

            
            
            searchBar.TextChanged += OnTextChanged;
            searchBar.SearchButtonPressed += OnSearchButtonPressed;
            searchResults.ItemsSource = DataService.Places;
            searchResults.ItemsSource = DataService.GetSearchResults(searchBar.Text);
            searchBar.TextChanged += OnTextChanged;

            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(searchBar);
            stack.Children.Add(map);
            stack.Children.Add(button);
            stack.Children.Add(slider);
            Content = stack;
        }
    }
}
