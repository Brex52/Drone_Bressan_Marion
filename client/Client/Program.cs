using System;
using System.Collections.Generic;
using Client.Sensors;
using Client.Protocols;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {

            // init sensors
            List<SensorInterface> sensors = new List<SensorInterface>();
            sensors.Add(new VirtualSpeedSensor());
            sensors.Add(new VirtualPositionSensor());
            sensors.Add(new VirtualBatterySensor());

            // define protocol
            //ProtocolInterface protocol = new Http("http://localhost:8011/drones/123");
            ProtocolInterface protocol = new MqttProtocol("localhost");

            // send data to server
            while (true)
            {
                foreach (SensorInterface sensor in sensors)
                {
                    var data = sensor.ToJson();

                    protocol.Send(data, sensor.GetSlug());

                    Console.WriteLine("Data sent: " + data);

                    System.Threading.Thread.Sleep(1000);

                }

            }

        }

    }

}
