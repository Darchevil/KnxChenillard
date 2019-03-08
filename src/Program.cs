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
            int speedCmd = 500;
            string LED = null;
            string command = null;
            Boolean loopContinue = true;

            Console.WriteLine("Connected !");

            while (true && loopContinue == true)
            {
                Console.WriteLine($@"Welcome ! Choose your Action :
                      [V] : Start chenillard
                      [C] : stop chenillard
                      [S] : Choose Speed 
                      [O] : Change Order 
                      Actual speed : " + chenillard.speed);

                command = Console.ReadLine();
                switch (command)
                {
                    case "V":
                        chenillard.StartChenillard();
                        break;
                    case "C":
                        chenillard.StopChenillard();
                        break;
                    case "S":
                        Console.WriteLine("Choose Your Speed in ms (minimum 500) :");
                        speedCmd = Convert.ToInt32(Console.ReadLine());
                        chenillard.speed = speedCmd;
                        break;
                    case "O":
                        Console.WriteLine("Choose Order : ");
                        Console.WriteLine("LED1 :");
                        LED = Console.ReadLine();
                        chenillard.Led1 = LED;
                        Console.WriteLine("LED2 :");
                        LED = Console.ReadLine();
                        chenillard.Led2 = LED;
                        Console.WriteLine("LED3 :");
                        LED = Console.ReadLine();
                        chenillard.Led3 = LED;
                        Console.WriteLine("LED4 :");
                        LED = Console.ReadLine();
                        chenillard.Led4 = LED;

                        chenillard.changeOrder();
                        break;

                    case "Q":
                        Console.WriteLine("Exiting....");
                        loopContinue = false;
                        break;

                }
            }

            Console.WriteLine("End... Press a Key to disconnect...");

            Console.ReadLine();

            Client.Disconnect();

            Console.WriteLine("Disconnected !");

            Console.ReadLine();


        }
        //Créer un thread pour démarrer et arrêter le chenillard 
    
    public static KnxConnectionTunneling connectToChenillard()
    {
        Console.WriteLine("Connecting...");
        var connection = new KnxConnectionTunneling("192.168.0.4", 3671, "192.168.0.101", 3671); //Connection à la maquette. L'adresse de la maquette est "192.168.0.5". Le port par défaut est 3671
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
