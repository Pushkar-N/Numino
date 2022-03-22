using log4net;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CamelTraceTrack
{
    public partial class Program
    {       

        private static bool ValidateRequest(UserCommand userCommand)
        {
            log.Info(string.Format("Inside ValidateRequest method"));
            switch (userCommand.Command)
            {
                //validate the cammel number..
                case Constants.WINNER:
                    log.Info(string.Format("Checking if the provided winning Camel input :{0} belongs to the list of Camels", userCommand.CamelNumber));
                    var winningCamel = racecamels.Where(r => r.Number.Equals(userCommand.CamelNumber)).Select(r => r).FirstOrDefault();
                    if (winningCamel == null)
                    {
                        log.Error(string.Format("Raising Invalid Camel exception. Provided input doesnt belong to the Camel list"));
                        throw new InvalidCamelException(userCommand.CamelNumber.ToString());
                    }
                    break;

                //checking for valid bet..
                case Constants.BET:
                    log.Info(string.Format("Checking if the provided bet input :{0} is valid", userCommand.BetAmount));
                    int betAmount;
                    if (userCommand.BetAmount <= Constants.DEFAULT || !(int.TryParse(userCommand.BetAmount.ToString(), out betAmount)))
                    {
                        log.Error(string.Format("Raising Invalid Bet exception. Provided input isnt a valid bet amount"));
                        throw new InvalidBetException(userCommand.BetAmount.ToString());
                    }
                    else
                        goto case Constants.WINNER;     //check if the bet is for a valid camel..                      

                //Checking if the restock or quit command have any other inputs followed..
                case Constants.RESTOCK:
                case Constants.QUIT:
                    log.Info(string.Format("Checking if the provided command :{0} is followed by any other input", userCommand.Command));
                    if (!userCommand.CamelNumber.Equals(Constants.DEFAULT))
                    {
                        log.Error(string.Format("Raising Command exception. Provided input isnt a valid command"));
                        throw new InvalidCommandException(userCommand.UserInputCommand);
                    }
                    break;

            }  

            return true;
           
        }
    }
}
