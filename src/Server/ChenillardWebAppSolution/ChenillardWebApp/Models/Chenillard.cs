using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Knx.Bus.Common.Configuration;
using Knx.Falcon.Sdk;
using Knx.Bus.Common;
using Knx.Bus.Common.GroupValues;
using System.Threading;

namespace ChenillardWebApp.Models
{
    public class Chenillard
    {
        Boolean isActive;
        Bus client;
        public int speed;
        public string Led1 = "0/1/1";
        public string Led2 = "0/1/2";
        public string Led3 = "0/1/3";
        public string Led4 = "0/1/4";
        string[] arrayLed;

        public Chenillard(Bus clientFromController)
        {
            this.client = clientFromController;
            this.isActive = false;
            this.speed = 1000; //1 second
            arrayLed = new string[] { Led1, Led2, Led3, Led4 };
            
        }

        public void StartChenillard()
        {
            Console.WriteLine("chenillard starting....");
            ThreadStart threadStart = new ThreadStart(GoChenillard);
            Thread threadChenillard = new Thread(threadStart);
            threadChenillard.Start();
            this.isActive = true;

        }

        public void GoChenillard()
        {
            Console.WriteLine("Go !");
            int i = 0;

            while (isActive == true)
            {
                if (i == 4)
                {
                    i = 0;
                }
                using (client)
                {
                    client.WriteValue(new GroupAddress(arrayLed[i]), new GroupValue(true), Priority.Low);
                    Thread.Sleep(speed);
                    client.WriteValue(new GroupAddress(arrayLed[i]), new GroupValue(false), Priority.Low);
                    i++;
                    client.WriteValue(new GroupAddress(arrayLed[i]), new GroupValue(true), Priority.Low);
                    Thread.Sleep(speed); //Attention, ne doit pas être en dessous de 500ms.
                    client.WriteValue(new GroupAddress(arrayLed[i]), new GroupValue(false), Priority.Low);
                    i++;
                }
            }
        }
        public void StopChenillard()
        {
            this.isActive = false;
        }

        public void changeOrder()
        {
            arrayLed = new string[] { Led1, Led2, Led3, Led4 };
        }

    }
}
