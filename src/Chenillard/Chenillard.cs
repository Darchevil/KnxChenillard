using KNXLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace ChenillardIotOfficial.ChenillardIot
{
    class Chenillard
    {
        KnxConnection client;
        Boolean isActive;
        public int speed;
        public string Led1 = "0/1/1";
        public string Led2 = "0/1/2";
        public string Led3 = "0/1/3";
        public string Led4 = "0/1/4";
        string[] arrayLed;

        public Chenillard(KnxConnection clientFromMain)
        {
            this.client = clientFromMain;
            this.isActive = false;
            this.speed = 500;
            arrayLed = new string[] { Led1, Led2, Led3, Led4 };
        }

        public void StartChenillard()
        {
            ThreadStart threadStart = new ThreadStart(GoChenillard);
            Thread threadChenillard = new Thread(threadStart);
            this.isActive = true;

        }
        public void GoChenillard()
        {
            int i = 0;

            while (isActive == true)
            {
                if(i == 4)
                {
                    i = 0;
                }
                //Thread.Sleep(700); //Attention, ne doit pas être en dessous de 500ms.
                client.Action(arrayLed[i], false);
                i++;
                client.Action(arrayLed[i], true);
                Thread.Sleep(speed); //Attention, ne doit pas être en dessous de 500ms.
                
                 //Attention, ne doit pas être en dessous de 500ms.
                //client.Action("0/1/2", false);
                //client.Action("0/1/3", true);
                //Thread.Sleep(700); //Attention, ne doit pas être en dessous de 500ms.
                //client.Action("0/1/3", false);
                //client.Action("0/1/4", true);
                //Thread.Sleep(700);
                //client.Action("0/1/4", false);
                //client.Action("0/1/1", true);
                //i++;
            }
        }
        public void StopChenillard()
        {
            this.isActive = false;
        }
        public void TestMaquette()
        {
            client.Action("0/1/1", true);
            Thread.Sleep(600);
            client.Action("0/1/1", false);

            client.Action("0/1/4", true);
            Thread.Sleep(600);
            client.Action("0/1/4", false);
        }
        public void changeOrder()
        {
            arrayLed = new string[] { Led1, Led2, Led3, Led4 };
        }
    }
}
