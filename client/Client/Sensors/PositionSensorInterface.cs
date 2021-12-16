using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Sensors
{
    interface PositionSensorInterface
    {
        int GetPositionX();
        int GetPositionY();
    }
}
