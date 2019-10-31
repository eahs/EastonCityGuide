using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace EastonCityGuide.Views
{
    public partial class MapPage : ContentPage
    {
        void Clickable(Pin pin,string name, string desc)
            {
                pin.Clicked += (sender, e) =>
                {
                    DisplayAlert(name,desc, "Close");
                };
            }

        readonly Map map;
        public MapPage()
        {
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

            
            var pin1 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(40.691216, -75.209130),
                Label = "Center Square",
                Address = "Historical Location"
            };
            var pin2 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(40.691389, -75.2125),
                Label = "State Theater",
                Address = "Entertainment"
            };
            var pin3 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(40.691944, -75.213611),
                Label = "Easton Public Library",
                Address = "Educational Location"
            };
            var pin4 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(40.687306, -75.217623),
                Label = "NorthHampton County Court House",
                Address = "Historical Location"
            };
            var pin5 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(40.691281, -75.210421),
                Label = "Easton Public Market",
                Address = "Consumer"
            };
            var pin6 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(40.690848, -75.210674),
                Label = "Sigal Museum",
                Address = "Educational Location"
            };
            var pin7 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(40.694538, -75.203715),
                Label = "Easton-Pburg Bridge",
                Address = "Historical Location"
            };
            var pin8 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(40.692109, -75.205205),
                Label = "Christopher Columbus Statue",
                Address = "Historical Location"
            };
            var pin9 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(40.690585, -75.213675),
                Label = "Nurture Nature Center",
                Address = "Educational Location"
            };

            Clickable(pin1, "Center Square", "The Centre Square was established in 1752 by Thomas and John Penn, the sons of William Penn. Many significant historical events occurred here including the public reading of the Declaration of Independence on July 8th, 1776.");
            Clickable(pin2, "State Theater", "");
            Clickable(pin3, "Easton Public Library", "The Easton Library Company started off as a subscription based book borrowing system in 1811. After seeing a need to reorganize the system, citizens applied for Andrew Carnegie’s library grant and secured $50,000 to construct a new library. The building was finished in 1903 and later expanded in 1911 and 1941.");
            Clickable(pin4, "NorthHampton County Court House", "");
            Clickable(pin5, "Easton Public Market", "");
            Clickable(pin6, "Sigal Museum", "");
            Clickable(pin7, "Easton-Pburg Bridge", "");
            Clickable(pin8, "Christopher Columbus Statue", "");
            Clickable(pin9, "Nurture Nature Center", "");


            map.Pins.Add(pin1);
            map.Pins.Add(pin2);
            map.Pins.Add(pin3);
            map.Pins.Add(pin4);
            map.Pins.Add(pin5);
            map.Pins.Add(pin6);
            map.Pins.Add(pin7);
            map.Pins.Add(pin8);
            map.Pins.Add(pin9);

            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            stack.Children.Add(slider);
            Content = stack;
        }

    }
}
