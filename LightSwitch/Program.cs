using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibCafe;

namespace LightSwitchConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int LightSwitches = 5;

            LightSwitch lightSwitch = new LightSwitch();
            lightSwitch.LightsOn += LightSwitch_LightsOn;
            lightSwitch.LightsOf += LightSwitch_LightsOf;

            for (int i = 0; i < LightSwitches; i++)
            {
                    lightSwitch.SwitchLights();         
            }

            Console.ReadKey();
        }

        private static void LightSwitch_LightsOf(object sender, EventArgs e)
        {
            Console.WriteLine($"Lights are off -- all dark.\n\n");
        }

        private static void LightSwitch_LightsOn(object sender, LightsOnEventArgs e)
        {
            Console.WriteLine($"{e.LightsColor} lights are on.");
        }
    }
}
