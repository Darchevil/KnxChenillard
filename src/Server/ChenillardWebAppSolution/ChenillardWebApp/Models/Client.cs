using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Knx.Bus.Common.Configuration;
using Knx.Falcon.Sdk;
using Knx.Bus.Common;
using Knx.Bus.Common.GroupValues;


namespace ChenillardWebApp.Models
{
    public class Client
    {
        public Bus clientBus = new Bus(new KnxIpTunnelingConnectorParameters("192.168.1.10", 0x0e57, false));
        public string stateChenillard { get; set; }
        public int speed { get; set; }
        public string led1;
        public string led2;
        public string led3;
        public string led4;
    }
}
