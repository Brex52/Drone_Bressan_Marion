using System.Threading;
using System.Threading.Tasks;
using MQTTnet.Client;
using MQTTnet;
using MQTTnet.Client.Options;
using MQTTnet.Client.Connecting;


namespace Client.Protocols
{
    class MqttProtocol : ProtocolInterface
    {
        private const string TOPIC_PREFIX = "iot2021test/";
        private IMqttClient mqttClient;
        private string endpoint;

        public MqttProtocol(string endpoint)
        {
            this.endpoint = endpoint;

            Connect().GetAwaiter().GetResult();
        }

        private async Task<MqttClientConnectResult> Connect()
        {
            var factory = new MqttFactory(); 

            var options = new MqttClientOptionsBuilder()
                .WithTcpServer(this.endpoint)
                .Build();

            mqttClient = factory.CreateMqttClient();

            return await mqttClient.ConnectAsync(options, CancellationToken.None);
        }

        public async void Send(string data, string sensor)
        {
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(TOPIC_PREFIX + sensor)
                .WithPayload(data)
                .WithExactlyOnceQoS()
                .Build();

            await mqttClient.PublishAsync(message, CancellationToken.None);
        }
    }
}
