using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace EastonCityGuide.Views
{
    public partial class RoutingPage : ContentPage
    {
        public RoutingPage()
        {
            object Option1;
            object Option2;
            Position location1;
            Position location2;

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

            Option1 = drop1.SelectedItem;
            Option2 = drop2.SelectedItem;
            location1 = EastonCityGuide.Services.DataService.Coordinates[1];
            location2 = EastonCityGuide.Services.DataService.Coordinates[1];

            button.Clicked += (sender, args) =>
            {
                DisplayAlert("Test","TEST","Close");
            };

            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(drop1);
            stack.Children.Add(drop2);
            stack.Children.Add(button);
            Content = stack;
        }
    }
}
