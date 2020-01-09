using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EastonCityGuide.Views.PinPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RiverSide : ContentPage
    {
        public RiverSide()
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;

            async void ButtonClicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new PinPages.RiverSide());
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
                Source = "RiverSide.jpg",
                Aspect = Aspect.AspectFit,
            };

            Label info = new Label
            {
                Text = "Located within a short walk North of Scott Park, Riverside park hosts a 586 seat amphitheatre, a large playground for children, and areas for recreation. " +
                       "Facilities may be rented out.",
            };

            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(voice);
            stack.Children.Add(photo);
            stack.Children.Add(info);
            Content = stack;
        }
    }
}