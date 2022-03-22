using System;
using System.Collections.Generic;
using System.Linq;

namespace CamelTraceTrack
{
    public partial class Program
    {
        private static List<Camel> racecamels;
        private static List<Inventory> inventories;
        

        #region Initialization
        /// <summary>
        /// InitializeValues for racecamels and inventories
        /// </summary>
        /// <param name="racecamels"></param>
        /// <param name="inventories"></param>
        private static void InitializeApplication()
        {
            log.Info("Initialising application.");

            log.Info("Initialising the Camel list.");
            racecamels = new List<Camel>();
            racecamels.Add(new Camel(1, Constants.THAT_DARN_GRAY_CAT, 5, true));
            racecamels.Add(new Camel(2, Constants.FORT_UTOPIA, 10, false));
            racecamels.Add(new Camel(3, Constants.COUNT_SHEEP, 9, false));
            racecamels.Add(new Camel(4, Constants.MS_TRAITOUR, 4, false));
            racecamels.Add(new Camel(5, Constants.REAL_PRINCESS, 3, false));
            racecamels.Add(new Camel(6, Constants.PA_KETTLE , 5, false));
            racecamels.Add(new Camel(7, Constants.GIN_STRINGER, 6, false));

            log.Info("Initialising the Inventory list.");
            inventories = new List<Inventory>();
            inventories.Add(new Inventory(100, 10));
            inventories.Add(new Inventory(20, 10));
            inventories.Add(new Inventory(10, 10));
            inventories.Add(new Inventory(5, 10));
            inventories.Add(new Inventory(1, 10));
            
            Camel.DisplayAllCamels(racecamels);
            Inventory.DisplayAllInventory(inventories);

        }

        #endregion

        private static void ProcessRequest(UserCommand userCommand)
        {     
            log.Info("Inside the ProcessRequest method");

            //route to designated path based on the command type..
            switch (userCommand.Command)
            {
                case Constants.WINNER:                        
                    Camel.SetWinningCamel(userCommand.CamelNumber, racecamels);    
                    break;

                case Constants.RESTOCK:
                    log.Info("Restock Inventory on request");
                    Console.WriteLine("Restocked Inventory");
                    InitializeApplication();
                    break;

                case Constants.QUIT:
                    log.Info("******************** Exiting application ******************** ");
                    Environment.Exit(0);
                    break;

                case Constants.BET:
                    //checking if the Camel number has won or lost...
                    var winningCamel = racecamels.Where(r => r.Number.Equals(userCommand.CamelNumber)).Select(r => r).FirstOrDefault();
                    if (winningCamel.DidWin.Equals(true))
                    {
                        log.Info(string.Format("Requested Camel : {0} is a winning Camel", userCommand.CamelNumber));
                        //check for sufficient inventory..
                        if (Inventory.CheckInventory(inventories, winningCamel.Odds * (int)(userCommand.BetAmount)))
                        {
                            Console.WriteLine(string.Format("Payout: {0}, {2}{1}", winningCamel.Name, winningCamel.Odds * (int)userCommand.BetAmount,Constants.DOLLAR_SIGN));
                            DispenseAmount(inventories, winningCamel.Odds * (int)(userCommand.BetAmount));
                        }
                    }
                    else
                    {
                        log.Info(string.Format("Raising No Payout Exception"));
                        throw new NoPayoutException(winningCamel.Name);
                    }
                    break;

                default:
                    {
                        log.Info(string.Format("Raising Invalid Command Exception"));
                        throw new InvalidCommandException(userCommand.UserInputCommand);
                    }
            }
                       
        }
    }
}
