using OpenNETCF.MQTT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica16
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Actuadores : ContentPage
    {

        MQTTClient mqtt;
        List<string> mensajes;

        int m = 0;
        List<Entry> entryList;
        public Actuadores()
        {
            InitializeComponent();
            mensajes = new List<string>();
            mqtt = new MQTTClient("broker.hivemq.com", 1883);
            mqtt.MessageReceived += Mqtt_MessageReceived;
            mqtt.Connect("AppMovilESP8266");
            mqtt.Subscriptions.Add(new Subscription("ServerProfeCarlos"));
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if (mensajes.Count > m)
                {
                    lstMensajes.ItemsSource = null;
                    lstMensajes.ItemsSource = mensajes;
                    m = mensajes.Count;
                }
                return true;
            });
        }

        private void Mqtt_MessageReceived(string topic, QoS qos, byte[] payload)
        {
            mensajes.Add(Encoding.UTF8.GetString(payload));
        }
        private void btnEncenderLed_Clicked(object sender, EventArgs e)
        {
            if (mqtt.IsConnected)
            {
                mqtt.Publish("ESP8266PruebaCin", "L1", QoS.FireAndForget, false);
            }
        }

        private void btnApagarLed_Clicked(object sender, EventArgs e)
        {
            if (mqtt.IsConnected)
            {
                mqtt.Publish("ESP8266PruebaCin", "L0", QoS.FireAndForget, false);
            }
        }

        

        private void btnMoverServo_Clicked(object sender, EventArgs e)
        {
            if (mqtt.IsConnected)
            {
                mqtt.Publish("ESP8266PruebaCin", "S" + entAngulo.Text, QoS.FireAndForget, false);
            }
        }

        private void btnEncenderFoco_Clicked(object sender, EventArgs e)
        {
            if (mqtt.IsConnected)
            {
                mqtt.Publish("ESP8266PruebaCin", "F1", QoS.FireAndForget, false);
            }
        }

        private void btnApagarFoco_Clicked(object sender, EventArgs e)
        {
            if (mqtt.IsConnected)
            {
                mqtt.Publish("ESP8266PruebaCin", "F0", QoS.FireAndForget, false);
            }
        }
    }
}