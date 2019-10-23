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
        readonly Map map;
        public MapPage()
        {
            var map = new Map(
                MapSpan.FromCenterAndRadius(
                        new Position(37, -122), Distance.FromMiles(0.3)))
            {
                IsVisible = true,
                IsEnabled = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            map.MoveToRegion(new MapSpan(new Position(0, 0), 360, 360));

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
                Label = "Center Fountain",
                Address = "This is a Fountain."
            };
            var pin2 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(40.690945, -75.209887),
                Label = "Crayola Experience",
                Address = "Color my impressed"
            };
            map.Pins.Add(pin1);
            map.Pins.Add(pin2);

            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            stack.Children.Add(slider);
            Content = stack;
        }

    }
}