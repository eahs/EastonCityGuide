using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EastonCityGuide.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace EastonCityGuide.Views
{
    public partial class MapPage : ContentPage
    {
        void Clickable(Pin pin,string name, string desc)
            {
                pin.Clicked += (sender, e) =>
                {
                    DisplayAlert(name,desc, "Close");
                };
            }

        readonly Map map;
        public MapPage()
        {
            var map = new Map(
                MapSpan.FromCenterAndRadius(
                        new Position(40, -75), Distance.FromMiles(0.3)))
            {
                IsVisible = true,
                IsEnabled = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
                
            };
            map.MoveToRegion(new MapSpan(new Position(40.691216, -75.209130), 0.01, 0.01));

            StackLayout slMap = new StackLayout
            {
                Children = { map },
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(10, 10, 10, 10)
            };
            map.MapType = MapType.Street;

            Slider slider = new Slider(1, 18, 1);
            slider.ValueChanged += (sender, e) =>
            {
                var zoomLevel = e.NewValue; // between 1 and 18
                var latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
                map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongdegrees, latlongdegrees));
            };



            var test = new Pin
            {

            };

            var pin1 = new GuidePin(new Position(40.691216, -75.209130), "Center Square", "Historical Location");
            var pin2 = new GuidePin(new Position(40.691389, -75.2125), "State Theater", "Entertainment");
            var pin3 = new GuidePin(new Position(40.691944, -75.213611), "Easton Public Library", "Educational Facility");
            var pin4 = new GuidePin(new Position(40.687306, -75.217623), "NorthHampton County Court House", "Historical Location");
            var pin5 = new GuidePin(new Position(40.691281, -75.210421), "Easton Public Market", "Consumer");
            var pin6 = new GuidePin(new Position(40.690848, -75.210674), "Sigal Museum", "Educational Location");
            var pin7 = new GuidePin(new Position(40.694538, -75.203715), "Easton-Pburg Bridge", "Historical Location");
            var pin8 = new GuidePin(new Position(40.692109, -75.205205), "Christopher Columbus Statue", "Historical Location");
            var pin9 = new GuidePin(new Position(40.690585, -75.213675), "Nurture Nature Center", "Educational LOcation");
            var pin10 = new GuidePin(new Position(40.692191, -75.205048), "RiverSide Park", "Recreation");
            var pin11 = new GuidePin(new Position(40.689864, -75.205397), "Larry Holmes Statue", "Historical Location");

            Clickable(pin1, "Center Square", "The Centre Square was established in 1752 by Thomas and John Penn, the sons of William Penn. Many significant historical events occurred here including the public reading of the Declaration of Independence on July 8th, 1776.");
            Clickable(pin2, "State Theater", "");
            Clickable(pin3, "Easton Public Library", "The Easton Library Company started off as a subscription based book borrowing system in 1811. After seeing a need to reorganize the system, citizens applied for Andrew Carnegie’s library grant and secured $50,000 to construct a new library. The building was finished in 1903 and later expanded in 1911 and 1941.");
            Clickable(pin4, "NorthHampton County Court House", "");
            Clickable(pin5, "Easton Public Market", "The Easton Public Market is a weekly opportunity for both vendors and customers to enjoy the great city of Easton. During the summer it takes place at the center square, but during the colder months it takes place inside, as to not make it too much of a hassle on people. This is also the location of many events within Easton such as GarlicFest, BaconFest, and Oktoberfest.");
            Clickable(pin6, "Sigal Museum", "The Sigal museum is an educational facility carrying hundreds of artifacts from throughout history. They carry all sorts of Native American artifacts, ancient weapons and living quarters, as well as even animal skeletons for viewing. The museum also holds a large gallery that rotates different selections of shows and exhibits.");
            Clickable(pin7, "Easton-Pburg Bridge", "");
            Clickable(pin8, "Christopher Columbus Statue", "Within September of 1928, a group of Italian Immigrants came together and funded the building of a 9-foot statue of explorer Christopher Columbus. The statue’s construction was halted after attacks from the KKK. Despite these attacks, the Italiant immigrants wanted a symbol of their country, and they chose Columbus. The statue was finally constructed in December of 1930.");
            Clickable(pin9, "Nurture Nature Center", "The Nurture Nature Center is an Educational location within the city of easton. The Nurture Nature Center is home to the Science on a Sphere, an educational device that projects scientific data onto a giant hanging sphere. This is the only one of its kind in Pennsylvania and one of only ~20 in the entire country of the United States. The location is also home to an art gallery, and telescopes available to look up into the night sky.");
            Clickable(pin10, "RiverSide Park", "Located within a short walk North of Scott Park, Riverside park hosts a 586 seat amphitheatre, a large playground for children, and areas for recreation. Facilities may be rented out.");
            Clickable(pin11, "Larry Holmes Statue", "Larry Holmes was a champion heavyweight boxer who was born in Easton, PA. He was inducted into the International Boxing Hall of Fame.");

            map.Pins.Add(pin1);
            map.Pins.Add(pin2);
            map.Pins.Add(pin3);
            map.Pins.Add(pin4);
            map.Pins.Add(pin5);
            map.Pins.Add(pin6);
            map.Pins.Add(pin7);
            map.Pins.Add(pin8);
            map.Pins.Add(pin9);
            map.Pins.Add(pin10);

            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            stack.Children.Add(slider);
            Content = stack;
        }

    }
}
