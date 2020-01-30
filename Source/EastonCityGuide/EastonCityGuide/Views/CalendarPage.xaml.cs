using System;
using System.Collections.Generic;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;

namespace GettingStarted
{
    public class App : Application
    {
        SfSchedule schedule;
        public App()
        {
            InitializeComponent();
            //Creating new instance for SfSchedule   
            schedule = new SfSchedule();
            MainPage = new ContentPage { Content = schedule };
        }
    }
}