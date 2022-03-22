using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamelTraceTrack
{   
    public class Camel
    {
        static protected ILog log = LogManager.GetLogger("CamelRaceTrack");

        public Camel(int number, string name, int odds, bool didwin)
        {
            this.Number = number;
            this.Name = name;
            this.Odds = odds;
            this.DidWin = didwin;            
        }        

        public int Number { get; set; }
        public string Name { get; set; }
        public int Odds { get; set; }
        public bool DidWin { get; set; }

        /// <summary>
        /// Displays the camels, its numberm odd and lost/win status.
        /// </summary>
        /// <param name="racecamels"></param>
        public static void DisplayAllCamels(List<Camel> racecamels)
        {
            log.Info("Inside the DisplayAllCamels method.");
            Console.WriteLine("Camels:");
            foreach (var camel in racecamels)
                Console.WriteLine(string.Format("{0},{1},{2},{3}", camel.Number, camel.Name, camel.Odds, camel.DidWin.Equals(true) ? "won" : "lost"));

            log.Info("All Camels displayed successfully.");
        }

        /// <summary>
        /// Resets the flag on the current winning camel and Sets the new requested winning camel.
        /// </summary>
        /// <param name="winningCamel"></param>
        /// <param name="racecamels"></param>
        public static void SetWinningCamel(int winningCamel, List<Camel> racecamels)
        {
            log.Info("Inside the SetWinningCamel method");
            foreach (var camel in racecamels)
            {
                if (!camel.Number.Equals(winningCamel) && camel.DidWin.Equals(true))
                {
                    camel.DidWin = false;
                    log.Info(string.Format("setting previous winning camel to FALSE. Camel No. : {1}, Camel Name : {0}", camel.Name,camel.Number));
                }
                else if (camel.Number.Equals(winningCamel))
                {
                    camel.DidWin = true;
                    log.Info(string.Format("setting current winning camel to TRUE. Camel No. : {1}, Camel Name : {0}", camel.Name, camel.Number));
                    Camel.DisplayAllCamels(racecamels);
                    return;
                }
            }
            log.Info("Exiting SetWinningCamel method");
        }

    }
}
