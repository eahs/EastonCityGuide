using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EastonCityGuide.Views
{
    public partial class RoutingPage : ContentPage
    {
        public RoutingPage()
        {
            object location1;
            object location2;

            async void RouteButtonClicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new RoutingPage());
            }

            Picker drop1 = new Picker
            {
                Title = "Pick Location 1",
                ItemsSource = EastonCityGuide.Services.DataService.Routing
            };
            Picker drop2 = new Picker
            {
                Title = "Pick Location 2",
                ItemsSource = EastonCityGuide.Services.DataService.Routing
            };
            Button button = new Button
            {
                Text = "Find Route"
            };

            location1 = drop1.SelectedItem;
            location2 = drop2.SelectedItem;

            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(drop1);
            stack.Children.Add(drop2);
            stack.Children.Add(button);
            Content = stack;
        }
    }
}
