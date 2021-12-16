using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Sensors
{
    class VirtualBatterySensor : SensorInterface, BatterySensorInterface
    {
        int Battery = 100;
        public int GetBattery()
        {
            Battery -= 10;
            if (Battery < 20)
            {
                System.Threading.Thread.Sleep(1000);
                Charge();
            }
            return Battery;
        }
        public void Charge()
        {
            Battery = 100;
        }
        public string ToJson()
        {
            return "{\"Battery\": " + GetBattery() + "}";
        }

        public string GetSlug()
        {
            return "Battery";
        }
    }
}
