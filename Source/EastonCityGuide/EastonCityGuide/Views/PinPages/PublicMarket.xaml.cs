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
    public partial class PublicMarket : ContentPage
    {
        public PublicMarket()
        {

            async void ButtonClicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new PinPages.PublicMarket());
            }

            Button voice = new Button
            {
                Text = "Audio Player",
            };
            voice.Clicked += (sender, e) =>
            {
                App.Music("Market");
            };

            Image photo = new Image
            {
                Source = "PublicMarket.jpg",
                Aspect = Aspect.AspectFit,
            };

            Label info = new Label
            {
                Text = "The Easton Public Market is a weekly opportunity for both vendors and customers to enjoy the great city of Easton. During the summer it takes place at " +
                       "the center square, but during the colder months it takes place inside, as to not make it too much of a hassle on people. This is also the location of " +
                       "many events within Easton such as GarlicFest, BaconFest, and Oktoberfest.",
            };

            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(voice);
            stack.Children.Add(photo);
            stack.Children.Add(info);
            Content = stack;
        }
    }
}