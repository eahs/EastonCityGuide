using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EastonCityGuide.Models; 
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Drawing;


namespace EastonCityGuide.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Init();
        }
        //Xamarin.Forms.Color xfColor2 = sdColor;

        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            Lbl_Username.TextColor = Constants.MainTextColor;
            //UserColor = Constants.MainTextColor;
            Lbl_Password.TextColor = Constants.MainTextColor;
            //PassColor = Constants.MainTextColor;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => SignInProcedure(s, e);
        }

        void SignInProcedure(object sender, EventArgs e)
        {
            User user = new User(Entry_Username.Text, Entry_Password.Text);
            if (user.CheckInformation())
            {
                DisplayAlert("Login", "Login Sucess", "Ok");
                Device.BeginInvokeOnMainThread(() => App.Current.MainPage = new MapPage());
            }
            else
            {
                DisplayAlert("Login", "Login Not Correct, empty", "Ok");
            }
        }
    }
}
