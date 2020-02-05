using System;
using System.Collections.Generic;
using EastonCityGuide.Models;

using Xamarin.Forms;

namespace EastonCityGuide.Views.PinPages
{
    public partial class CenterSquare : ContentPage
    {
        public CenterSquare()
        {

            async void ButtonClicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new PinPages.CenterSquare());
            }

            Button voice = new Button
            {
                Text = "Audio Player",
            };
            voice.Clicked += (sender, e) =>
            {
                App.Music("CenterSquare");
            };

            Image photo = new Image
            {
                Source = "CenterSquare.jpg",
                Aspect = Aspect.AspectFit,
            };

            Label info = new Label
            {
                Text = "The Center Square was established in 1752 by Thomas and John Penn, the sons of William Penn. " +
                       "Many significant historical events occurred here including the public reading of the Declaration " +
                       "of Independence on July 8th, 1776.",
            };

            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(voice);
            stack.Children.Add(photo);
            stack.Children.Add(info);
            Content = stack;

            
        }
    }
}
