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
    public partial class NurtureNature : ContentPage
    {
        public NurtureNature()
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;

            async void ButtonClicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new PinPages.NurtureNature());
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
                Source = "NurtureNature.jpg",
                Aspect = Aspect.AspectFit,
            };

            Label info = new Label
            {
                Text = "The Nurture Nature Center is an Educational location within the city of easton. The Nurture Nature Center is home to the Science on a Sphere, " +
                       "an educational device that projects scientific data onto a giant hanging sphere. This is the only one of its kind in Pennsylvania and one of " +
                       "only ~20 in the entire country of the United States. The location is also home to an art gallery, and telescopes available to look up into the night sky.",
            };

            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(voice);
            stack.Children.Add(photo);
            stack.Children.Add(info);
            Content = stack;
        }
    }
}