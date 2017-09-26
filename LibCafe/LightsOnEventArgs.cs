using System;

namespace LibCafe
{
    public class LightsOnEventArgs : EventArgs
    {
        private static string[] LightsColors = { "Red", "Blue", "Green", "White" };
        public static Random random = new Random();

        public string LightsColor { get; }

        public LightsOnEventArgs()
        {
            LightsColor = LightsColors[random.Next(0, LightsColors.Length)];
        }
    }
}