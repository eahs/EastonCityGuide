using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EastonCityGuide.Views.PinPages
{
    public partial class StateTheatre : ContentPage
    {
        public StateTheatre()
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;

            async void ButtonClicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new PinPages.StateTheatre());
            }

            Button voice = new Button
            {
                Text = "Audio Player",
            };
            voice.Clicked += (sender, e) =>
            {
                player.Load("Rick.mp3");
                player.Play();
            };

            Image photo = new Image
            {
                Source = "StateTheatre.jpg",
                Aspect = Aspect.AspectFit,
            };

            Label info = new Label
            {
                Text = "Originally the Northampton National Bank, the State Theatre went through many renovations and was a major entertainment hub. Today, it is used as " +
                       "a show venue and hosts the annual Freddy Awards.",
            };

            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(voice);
            stack.Children.Add(photo);
            stack.Children.Add(info);
            Content = stack;
        }
    }
}
