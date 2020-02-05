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
    public partial class PublicLibrary : ContentPage
    {
        public PublicLibrary()
        {

            async void ButtonClicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new PinPages.PublicLibrary());
            }

            Button voice = new Button
            {
                Text = "Audio Player",
            };
            voice.Clicked += (sender, e) =>
            {
                App.Music("Library");
            };

            Image photo = new Image
            {
                Source = "PublicLibrary.jpg",
                Aspect = Aspect.AspectFit,
            };

            Label info = new Label
            {
                Text = "The Easton Library Company started off as a subscription based book borrowing system in 1811. After seeing a need to reorganize the system, " +
                       "citizens applied for Andrew Carnegie’s library grant and secured $50,000 to construct a new library. The building was finished in 1903 and " +
                       "later expanded in 1911 and 1941.",
            };

            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(voice);
            stack.Children.Add(photo);
            stack.Children.Add(info);
            Content = stack;
        }
    }
}