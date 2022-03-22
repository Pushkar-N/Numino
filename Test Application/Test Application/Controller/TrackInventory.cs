using log4net;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CamelTraceTrack
{
    public partial class Program
    {
        public static void DispenseAmount(List<Inventory> inventories, int amount)
        {
            log.Info(string.Format("Isnide DispenseAmount method."));
            //logic to extract minimum number of currency notes..
            int[] notes = inventories.Select(x => x.Amount).ToArray();
            int[] noteCounter = new int[notes.Count()];
            for (int i = 0; i < notes.Count(); i++)
            {
                if (amount >= notes[i])
                {
                    //use maximum number of available notes from inventory.
                    noteCounter[i] = (amount / notes[i]) > inventories[i].Count ? inventories[i].Count : (amount / notes[i]);
                    amount = amount - noteCounter[i] * notes[i];
                }
            }

            Console.WriteLine("Dispensing:");
            for (int i = notes.Count() - 1; i >= 0; i--)
            {
                Console.WriteLine(string.Format("{2}{0},{1}", notes[i], noteCounter[i], Constants.DOLLAR_SIGN));
                inventories[i].Count -= noteCounter[i];
            }

            Inventory.DisplayAllInventory(inventories);
        }
    }
}
