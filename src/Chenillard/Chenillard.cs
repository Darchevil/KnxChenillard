using KNXLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChenillardIotOfficial.ChenillardIot
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

                Thread.Sleep(700); //Attention, ne doit pas être en dessous de 500ms.
                client.Action("0/1/1", true);
                Thread.Sleep(700); //Attention, ne doit pas être en dessous de 500ms.
                client.Action("0/1/1", false);
                client.Action("0/1/2", true);
                Thread.Sleep(700); //Attention, ne doit pas être en dessous de 500ms.
                client.Action("0/1/2", false);
                client.Action("0/1/3", true);
                Thread.Sleep(700); //Attention, ne doit pas être en dessous de 500ms.
                client.Action("0/1/3", false);
                client.Action("0/1/4", true);
                Thread.Sleep(700);
                client.Action("0/1/4", false);
                client.Action("0/1/1", true);
                i++;
            }
        }
        public void StopChenillard()
        {
            this.isActive = false;
        }
    }
}
