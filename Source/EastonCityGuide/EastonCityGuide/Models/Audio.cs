using System;


namespace EastonCityGuide.Models
{
    public class Audio
    {
        public void Audio()
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
        }
    }
}
