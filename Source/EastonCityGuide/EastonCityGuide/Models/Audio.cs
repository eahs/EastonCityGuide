using System;


namespace EastonCityGuide.Models
{
    public class Audio
    {
        public void iGiveUp()
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
        }
    }
}
