using System;
using System.Collections.Generic;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace EastonCityGuide.Views
{
    public partial class RoutingPage : ContentPage
    {
        public RoutingPage()
        {
            object Option1 = null;
            object Option2;
            Location location1 = null;
            Location location2;

            async void ButtonClicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new RoutingPage());
            }

            Picker drop1 = new Picker
            {
                Title = "Pick Location 1",
                ItemsSource = Services.DataService.Routing
            };
            Picker drop2 = new Picker
            {
                Title = "Pick Location 2",
                ItemsSource = Services.DataService.Routing
            };
            Button button = new Button
            {
                Text = "Find Route"
            };


            button.Clicked += (sender, args) =>
            {

                Option1 = drop1.SelectedItem;
                Option2 = drop2.SelectedItem;
                location1 = Services.DataService.Coordinates[1];
                location2 = Services.DataService.Coordinates[1];

                if (Option1 == null || location1== null)
                {
                    DisplayAlert("Error", "Please Input a Location into Both DropDown", "Close");
                }
                else
                {
                    var options = new MapLaunchOptions { Name = Option1.ToString() };
                }


                //Xamarin.Essentials.Map.OpenAsync(location1/*, options*/);
            };

            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(drop1);
            stack.Children.Add(drop2);
            stack.Children.Add(button);
            Content = stack;
        }
    }
}
