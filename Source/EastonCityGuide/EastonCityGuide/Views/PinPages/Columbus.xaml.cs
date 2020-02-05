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
    public partial class Columbus : ContentPage
    {
        public Columbus()
        {

            async void ButtonClicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new PinPages.Columbus());
            }

            Button voice = new Button
            {
                Text = "Audio Player",
            };
            voice.Clicked += (sender, e) =>
            {
                App.Music("Columbus");
            };

            Image photo = new Image
            {
                Source = "Columbus.jpg",
                Aspect = Aspect.AspectFit,
            };

            Label info = new Label
            {
                Text = "Within September of 1928, a group of Italian Immigrants came together and funded the building of a 9-foot statue of explorer Christopher Columbus. " +
                       "The statue’s construction was halted after attacks from the KKK. Despite these attacks, the Italian immigrants wanted a symbol of their country, and " +
                       "they chose Columbus. The statue was finally constructed in December of 1930.",
            };

            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(voice);
            stack.Children.Add(photo);
            stack.Children.Add(info);
            Content = stack;
        }
    }
}