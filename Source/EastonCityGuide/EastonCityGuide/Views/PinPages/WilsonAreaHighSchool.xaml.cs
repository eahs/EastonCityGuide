using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EastonCityGuide.Views.PinPages
{
    public partial class WilsonAreaHighSchool : ContentPage
    {
        public WilsonAreaHighSchool()
        {

            async void ButtonClicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new PinPages.WilsonAreaHighSchool());
            }

            Button voice = new Button
            {
                Text = "Audio Player",
            };
            voice.Clicked += (sender, e) =>
            {
                App.Music("WAHS");
            };

            Image photo = new Image
            {
                Source = "",
                Aspect = Aspect.AspectFit,
            };

            Label info = new Label
            {
                Text = "TEST",
            };

            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(voice);
            stack.Children.Add(photo);
            stack.Children.Add(info);
            Content = stack;
        }
    }
}
