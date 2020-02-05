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
    public partial class SigalMuseum : ContentPage
    {
        public SigalMuseum()
        {

            async void ButtonClicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new PinPages.SigalMuseum());
            }

            Button voice = new Button
            {
                Text = "Audio Player",
            };
            voice.Clicked += (sender, e) =>
            {
                App.Music("Sigal");
            };

            Image photo = new Image
            {
                Source = "SigalMuseum.jpg",
                Aspect = Aspect.AspectFit,
            };

            Label info = new Label
            {
                Text = "The Sigal museum is an educational facility carrying hundreds of artifacts from throughout history. They carry all sorts of Native American artifacts, " +
                       "ancient weapons and living quarters, as well as even animal skeletons for viewing. The museum also holds a large gallery that rotates different selections of " +
                       "shows and exhibits.",
            };

            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(voice);
            stack.Children.Add(photo);
            stack.Children.Add(info);
            Content = stack;
        }
    }
}