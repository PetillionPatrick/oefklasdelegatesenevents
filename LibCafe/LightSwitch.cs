using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCafe
{
    public delegate void LightsOnHandler(object sender, LightsOnEventArgs e);
    public delegate void LightsOfHandler(object sender, EventArgs e);
    class LightSwitch
    {
        public event LightsOnHandler LightsOn;
        public event LightsOfHandler LightsOf;

        public int LightsPower = 0;

        public void SwitchLights()
        {
            if (LightsPower == 0)
            { 
                LightsOn?.Invoke(this, new LightsOnEventArgs());
                LightsPower = 1;
            }
            if (LightsPower == 1)
            {
                LightsOf?.Invoke(this, EventArgs.Empty);
                LightsPower = 0;
            }
        }

    }
}
