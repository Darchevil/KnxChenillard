using System;
using System.Collections.Generic;
using System.Text;
using KNXLib;
using System.Threading;

namespace ChenillardIot
{
    class Chenillard
    {
        KnxConnection client;
        Boolean isActive;
        public Chenillard(KnxConnection clientFromMain)
        {
            this.client = clientFromMain;
            this.isActive = false;
        }

        public void StartChenillard()
        {
            Console.WriteLine("Turning-On Chenillard");
            int i = 0;
            this.isActive = true;
            while (i < 3)
            {
                
                client.Action("1/0/3", false);
                client.Action("1/0/0", true);
                Thread.Sleep(700); //Attention, ne doit pas être en dessous de 500ms.
                client.Action("1/0/0", false);
                client.Action("1/0/1", true);
                Thread.Sleep(700);
                client.Action("1/0/1", false);
                client.Action("1/0/2", true);
                Thread.Sleep(700);
                client.Action("1/0/2", false);
                client.Action("1/0/3", true);
                Thread.Sleep(700);
                i++;
            }
        }
        public void StopChenillard()
        {
            this.isActive = false;
        }
    }
}
