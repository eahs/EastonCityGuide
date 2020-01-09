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
    public partial class EPBridge : ContentPage
    {
        public EPBridge()
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;

            async void ButtonClicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new PinPages.EPBridge());
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
                Source = "EPBridge.jpg",
                Aspect = Aspect.AspectFit,
            };

            Label info = new Label
            {
                Text = "TEMP",
            };

            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(voice);
            stack.Children.Add(photo);
            stack.Children.Add(info);
            Content = stack;
        }
    }
}