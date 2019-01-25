using System;
using System.Threading;
using KNXLib;

namespace ChenillardIot
{
    class Program
    {
        static void Main(string[] args)
        {
            //Connection to the KNX 
            KnxConnectionTunneling Client;
            Client = connectToChenillard();

            Console.WriteLine("Connected !");
            //Chenillard chenillard = new Chenillard(Client);
            Client.Action("1/0/1", false);
            Thread.Sleep(800);
            Client.Action("1/0/1", true);
            //chenillard.StartChenillard();

            Console.ReadLine();

            Client.Disconnect();

            Console.WriteLine("Disconnected !");

            Console.ReadLine();


        }
        public static KnxConnectionTunneling connectToChenillard()
        {
            Console.WriteLine("Connecting...");
            var connection = new KnxConnectionTunneling("192.168.0.5", 3671, "192.168.0.100", 3671); //Connection à la maquette. L'adresse de la maquette est "192.168.0.5". Le port par défaut est 3671
            connection.Connect();
            connection.KnxEventDelegate += Event;
            Console.WriteLine("Connected To the KNX");
            return connection;
            
        }
        static void Event(string address, string state)
        {
            var connectionClient = new KnxConnectionTunneling("192.168.0.5", 3671, "192.168.0.100", 3671);
            if (address == "0/0/1")
            {
                Console.WriteLine("Start Chenillard");
                connectionClient.Action("1/0/3", false);
                connectionClient.Action("1/0/0", true);
                Thread.Sleep(700); //Attention, ne doit pas être en dessous de 500ms.
                connectionClient.Action("1/0/0", false);
                connectionClient.Action("1/0/1", true);
                Thread.Sleep(700);
                connectionClient.Action("1/0/1", false);
                connectionClient.Action("1/0/2", true);
                Thread.Sleep(700);
                connectionClient.Action("1/0/2", false);
                connectionClient.Action("1/0/3", true);
                Thread.Sleep(700);
            }

            if (address == "0/0/2")
            {
                Console.WriteLine("Stop Chenillard");

            }
            Console.WriteLine("New Event: device " + address + " has status " + state);
        }

        
    }
}
