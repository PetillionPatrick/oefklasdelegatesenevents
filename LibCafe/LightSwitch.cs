using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCafe
{
    public delegate void LightsOnHandler(object sender, LightsOnEventArgs e);
    public delegate void LightsOfHandler(object sender, EventArgs e);
    public class LightSwitch
    {
        public event LightsOnHandler LightsOn;
        public event LightsOfHandler LightsOf;

        private string[] lightsPowers = { "Of", "On" };
        public string LightsPower = "Of";

        public void SwitchLights()
        {
            if (LightsPower == "Of")
            { 
                LightsOn?.Invoke(this, new LightsOnEventArgs());
                LightsPower = lightsPowers[1];
            }
            if (LightsPower == "On")
            {
                LightsOf?.Invoke(this, EventArgs.Empty);
                LightsPower = lightsPowers[0];
            }
        }

    }
}
