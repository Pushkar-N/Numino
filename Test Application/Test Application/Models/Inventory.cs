using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamelTraceTrack
{
    public class Inventory
    {
        static protected ILog log = LogManager.GetLogger("CamelRaceTrack");

        public int Amount { get; set; }
        public int Count { get; set; }

        public Inventory(int amount, int count)
        {
            log.Info(string.Format("Setting Inventory Amount : {0} and Count : {1}", amount, count));
            this.Amount = amount;
            this.Count = count;
        }

        public static int GetTotalAmount(List<Inventory> inventories)
        {
            foreach (var inv in inventories)
                log.Info(string.Format("Displaying Individual Inventory amount : {0} * {1}", inv.Amount, inv.Count));
            return inventories.Sum(item => item.Amount * item.Count);
        }                

        public static void DisplayAllInventory(List<Inventory> inventories)
        {
            Console.WriteLine("Inventory:");
            foreach (var inventory in inventories.OrderBy(x=>x.Amount))
                Console.WriteLine(string.Format("{2}{0},{1}", inventory.Amount, inventory.Count,Constants.DOLLAR_SIGN));
        }

        public static bool CheckInventory(List<Inventory> inventories, int amount)
        {
            log.Info(string.Format("Checking in inventory for amount : {0}",amount));
            int totalAmount = Inventory.GetTotalAmount(inventories);
            log.Info(string.Format("Total Inventory value : {0}", totalAmount));
            if (totalAmount < amount)
            {
                Console.WriteLine(string.Format("Insufficient Funds:{0}", amount));
                log.Info(string.Format("Insufficient Funds : {0}", amount));
                return false;                
            }
            else
                return true;
        }
    }
}
