using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EastonCityGuide.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using EastonCityGuide.Services;

namespace EastonCityGuide.Views
{

    public partial class MapPage : ContentPage
    {
        protected override void OnAppearing() => App.Music("MainPage");

        List<string> places = DataService.Places;
        List<Position> locations = DataService.Locations;

        
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

            List<GuidePin> pins = new List<GuidePin>();

            pins.Add(new GuidePin { Position = new Position(40.691216, -75.209130), Label = "Center Square",                   Address = "Historical Location",  Type = PinType.Place, PinPageType = typeof(PinPages.CenterSquare)         });
            pins.Add(new GuidePin { Position = new Position(40.691389, -75.212500), Label = "State Theater",                   Address = "Entertainment",        Type = PinType.Place, PinPageType = typeof(PinPages.StateTheatre)         });
            pins.Add(new GuidePin { Position = new Position(40.691944, -75.213611), Label = "Easton Public Library",           Address = "Educational Facility", Type = PinType.Place, PinPageType = typeof(PinPages.PublicLibrary)        });
            pins.Add(new GuidePin { Position = new Position(40.687306, -75.217623), Label = "NorthHampton County Court House", Address = "Historical Location",  Type = PinType.Place, PinPageType = typeof(PinPages.CourtHouse)           });
            pins.Add(new GuidePin { Position = new Position(40.691281, -75.210421), Label = "Easton Public Market",            Address = "Recreation",           Type = PinType.Place, PinPageType = typeof(PinPages.PublicMarket)         });
            pins.Add(new GuidePin { Position = new Position(40.690848, -75.210674), Label = "Sigal Museum",                    Address = "Educational Facility", Type = PinType.Place, PinPageType = typeof(PinPages.SigalMuseum)          });
            pins.Add(new GuidePin { Position = new Position(40.694538, -75.203715), Label = "Easton-PBurg Bridge",             Address = "Historical Location",  Type = PinType.Place, PinPageType = typeof(PinPages.EPBridge)             });
            pins.Add(new GuidePin { Position = new Position(40.692109, -75.205205), Label = "Christopher Columbus Statue",     Address = "Historical Location",  Type = PinType.Place, PinPageType = typeof(PinPages.Columbus)             });
            pins.Add(new GuidePin { Position = new Position(40.690585, -75.213675), Label = "Nurture Nature Center",           Address = "Educational Dacility", Type = PinType.Place, PinPageType = typeof(PinPages.NurtureNature)        });
            pins.Add(new GuidePin { Position = new Position(40.692191, -75.205048), Label = "RiverSide Park",                  Address = "Recreation",           Type = PinType.Place, PinPageType = typeof(PinPages.RiverSide)            });
            pins.Add(new GuidePin { Position = new Position(40.689864, -75.205397), Label = "Larry Holmes Statue",             Address = "Historical Location",  Type = PinType.Place, PinPageType = typeof(PinPages.LarryHolmes)          });
            pins.Add(new GuidePin { Position = new Position(40.682571, -75.252674), Label = "Easton Area High School",         Address = "Educational Facility", Type = PinType.Place, PinPageType = typeof(PinPages.EastonAreaHighSchool) });
            pins.Add(new GuidePin { Position = new Position(40.682574, -75.250029), Label = "Vietnam Memorial",                Address = "Historical Location",  Type = PinType.Place, PinPageType = typeof(PinPages.VietnamMemorial)      });
            pins.Add(new GuidePin { Position = new Position(40.696192, -75.228143), Label = "Karl Stirner Arts Trail",         Address = "Entertainment",        Type = PinType.Place, PinPageType = typeof(PinPages.ArtsTrail)            });
            pins.Add(new GuidePin { Position = new Position(40.691737, -75.225713), Label = "Cottingham Stadium",              Address = "Historical Location",  Type = PinType.Place, PinPageType = typeof(PinPages.Cottingham)           });
            pins.Add(new GuidePin { Position = new Position(40.690811, -75.227308), Label = "Paxinosa Elementary School",      Address = "Educational Facility", Type = PinType.Place, PinPageType = typeof(PinPages.Paxinosa)             });
            pins.Add(new GuidePin { Position = new Position(40.684204, -75.243630), Label = "Wilson Area High School",         Address = "Educational Facility", Type = PinType.Place, PinPageType = typeof(PinPages.WilsonAreaHighSchool) });


            // Set up all the click events and add each pin to the map
            foreach (var pin in pins)
            {
                pin.Clicked += (sender, e) => {
                    GuidePin p = (GuidePin)sender;
                    Navigation.PushAsync((Page)Activator.CreateInstance(p.PinPageType));
                    };

                map.Pins.Add(pin);
            }


            SearchBar searchBar = new SearchBar
            {
                Placeholder = "Search Items...",
                PlaceholderColor = Color.Gray,
                TextColor = Color.Gray,
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(SearchBar)),
                FontAttributes = FontAttributes.None
            };

            ListView searchResults = new ListView
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill
            };

            void OnTextChanged(object sender, EventArgs e)
            {
                searchBar = (SearchBar)sender;
                searchResults.ItemsSource = DataService.GetSearchResults(searchBar.Text);
            }

            void OnSearchButtonPressed(object sender, EventArgs e)
            {
                searchBar = (SearchBar)sender;
                searchResults.ItemsSource = DataService.GetSearchResults(searchBar.Text);

                for (int i = 0; i < places.Count; i++)
                {
                    if (searchBar.Text.ToLower().Equals(places[i].ToLower()))
                    {
                        map.MoveToRegion(new MapSpan(locations[i], 0.001, 0.001));
                    }
                }
            }
            
            searchBar.TextChanged += OnTextChanged;
            searchBar.SearchButtonPressed += OnSearchButtonPressed;
            searchResults.ItemsSource = DataService.Places;
            searchResults.ItemsSource = DataService.GetSearchResults(searchBar.Text);
            searchBar.TextChanged += OnTextChanged;

            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(searchBar);
            stack.Children.Add(map);
            stack.Children.Add(slider);
            Content = stack;
        }
    }
}
