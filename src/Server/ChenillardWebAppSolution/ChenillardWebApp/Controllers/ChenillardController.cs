using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChenillardWebApp.Models;
using System.Net.WebSockets;
using Microsoft.AspNetCore.Mvc;
using Knx.Bus.Common.Configuration;
using Knx.Falcon.Sdk;
using Knx.Bus.Common;
using Knx.Bus.Common.GroupValues;
using System.Threading;

namespace ChenillardWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class chenillardController : ControllerBase
    {

        static Boolean isActive = true;
        public int speed = 1000;
        public string Led1 = "0/1/1";
        public string Led2 = "0/1/2";
        public string Led3 = "0/1/3";
        public string Led4 = "0/1/4";
        string[] arrayLed;
        //public static Bus bus = new Bus(new KnxIpTunnelingConnectorParameters("192.168.1.10", 0x0e57, false));
        //Chenillard chen = new Chenillard(bus);


        // ****************************************************************************
        //              POST METHODS
        // *****************************************************************************

        
        [HttpPost]
        public void launchChen(Client clientChen)
        {
            ChenillardReply CR = new ChenillardReply();
            Led1 = clientChen.led1;
            Led2 = clientChen.led2;
            Led3 = clientChen.led3;
            Led4 = clientChen.led4;
            CR.stateChenillard = clientChen.stateChenillard;
            CR.speed = clientChen.speed;
            if (clientChen.stateChenillard == "start")
            {
                isActive = true;
                //speed = clientChen.speed;
                arrayLed = new string[] { Led1, Led2, Led3, Led4 };
                ThreadStart thread = new ThreadStart(goChen);
                Thread threadChen = new Thread(thread);
                if (!threadChen.IsAlive)
                {
                    threadChen.Start();
                }
            }
            if(clientChen.stateChenillard == "stop")
            {
                isActive = false;
            }
            
        }

        [HttpPost ("ChangeSpeed")]
        public void changeSpeed(Client clientChen)
        {
            ChenillardReply CR = new ChenillardReply();

            speed = clientChen.speed;
        }

        [HttpPost ("ChangeOrder")]
        public void changeOrder(Client clientChen)
        {
            Led1 = clientChen.led1;
            Led2 = clientChen.led2;
            Led3 = clientChen.led3;
            Led4 = clientChen.led4;

        }

        

        //******************************************METHODS***********************************************
        //************************************************************************************************


        public void goChen() //The thread of the chenillard 
        {

            using (Bus bus = new Bus(new KnxIpTunnelingConnectorParameters("192.168.1.10", 0x0e57, false)))
            {
                bus.Connect();
                bus.GroupValueReceived += Bus_GroupValueReceived;
                while (isActive == true)
                {
                    bus.WriteValue(new GroupAddress(Led4), new GroupValue(false), Priority.Low); //Permet d'écrire une valeur sur une adresse de groupe
                    bus.WriteValue(new GroupAddress(Led1), new GroupValue(true), Priority.Low); //Permet d'écrire une valeur sur une adresse de groupe
                    Thread.Sleep(speed);
                    bus.WriteValue(new GroupAddress(Led1), new GroupValue(false), Priority.Low); //Permet d'écrire une valeur sur une adresse de groupe
                    bus.WriteValue(new GroupAddress(Led2), new GroupValue(true), Priority.Low); //Permet d'écrire une valeur sur une adresse de groupe
                    Thread.Sleep(speed);
                    bus.WriteValue(new GroupAddress(Led2), new GroupValue(false), Priority.Low); //Permet d'écrire une valeur sur une adresse de groupe
                    bus.WriteValue(new GroupAddress(Led3), new GroupValue(true), Priority.Low); //Permet d'écrire une valeur sur une adresse de groupe
                    Thread.Sleep(speed);
                    bus.WriteValue(new GroupAddress(Led3), new GroupValue(false), Priority.Low); //Permet d'écrire une valeur sur une adresse de groupe
                    bus.WriteValue(new GroupAddress(Led4), new GroupValue(true), Priority.Low); //Permet d'écrire une valeur sur une adresse de groupe
                    Thread.Sleep(speed);

                }
            }

        }

        private void  Bus_GroupValueReceived(GroupValueEventArgs obj)
        {
            if (obj != null)
            {
                String ResultText = "GA: " + obj.Address.ToString() +
                                    " Sender PA: " + obj.IndividualAddress.ToString() +
                                    " Priority: " + obj.TelegramPriority.ToString() +
                                    " Value: " + obj.Value.ToString();

                
            }
        }
        

        public void changeOrder()
        {
            arrayLed = new string[] { Led1, Led2, Led3, Led4 };
        }
    }
}
