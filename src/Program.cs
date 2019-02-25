using KNXLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ChenillardIotOfficial.ChenillardIot;

namespace ChenillardIotOfficial
{
    class Program
    {
        static KnxConnectionTunneling Client = connectToChenillard();
        static Chenillard chenillard = new Chenillard(Client);

        static void Main(string[] args)
        {
            //Connection to the KNX 
            //KnxConnectionTunneling Client;
            //Client = connectToChenillard();
            //Chenillard chenillard = new Chenillard(Client);

            Console.WriteLine("Connected !");
            //Chenillard chenillard = new Chenillard(Client);
            
            chenillard.StartChenillard();

            Console.ReadLine();

            Client.Disconnect();

            Console.WriteLine("Disconnected !");

            Console.ReadLine();


        }
        //Créer un thread pour démarrer et arrêter le chenillard 
    
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
        //var connectionClient = new KnxConnectionTunneling("192.168.0.5", 3671, "192.168.0.105", 3671);
       
        Console.WriteLine("New Event: device " + address + " has status " + state);
        if(address == "0/3/1")
            {
                Console.WriteLine("0/3/1 is pressed");
                
                chenillard.StartChenillard();
            }
        if(address == "0/3/2")
            {
                chenillard.StopChenillard();
            }
    }
        public static void startChenillard()
        {
            
        }
}
}
