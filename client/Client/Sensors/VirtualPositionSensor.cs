using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Sensors
{
    class VirtualPositionSensor : SensorInterface, PositionSensorInterface
    {
        public string ToJson()
        {
            int positionX;
            int positionY;
            
           
            positionX = GetPositionX();
            positionY = GetPositionY();
            
            
            return "{\"positionX\": " + positionX + "," + "\"position\": " + positionY + "}";
        }

        public int GetPositionX()
        {
            var randomX = new Random();
            return randomX.Next(1000);
        }
        public int GetPositionY()
        {
            var randomY = new Random();
            return randomY.Next(1000);
        }

        public string GetSlug()
        {
            return "Position";
        }

    }
}
