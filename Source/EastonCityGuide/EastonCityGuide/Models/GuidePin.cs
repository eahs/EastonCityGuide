using System;
using Xamarin.Forms.Maps;

namespace EastonCityGuide.Models
{
    public class GuidePin : Pin
    {
        public GuidePin(Position coordinates, string label, string address) 
        {
            Type = PinType.Place;
            Position = coordinates;
            Label = label;
            Address = address;
        }
    }
}
