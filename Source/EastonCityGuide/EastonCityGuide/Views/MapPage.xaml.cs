using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

public class MapPage : ContentPage
{
    public MapPage()
    {
        var map = new Map(
            MapSpan.FromCenterAndRadius(
                    new Position(37, -122), Distance.FromMiles(0.3)))
        {
            IsShowingUser = true,
            HeightRequest = 100,
            WidthRequest = 960,
            VerticalOptions = LayoutOptions.FillAndExpand
        };
        map.MapType = MapType.Street;
        var stack = new StackLayout { Spacing = 0 };
        stack.Children.Add(map);
        Content = stack;

    }
}