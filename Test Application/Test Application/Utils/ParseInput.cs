using log4net;
using System;
using System.Linq;


namespace CamelTraceTrack
{
    public static class ParseInput
    {
        static ILog log = LogManager.GetLogger("CamelRaceTrack");

        public static void ParseInputData(out UserCommand userCommand, string userInput)
        {
            log.Info("Initializing user command info object");
            userCommand = new UserCommand();

            //setting a default values to the input commands.
            log.Info("Setting defaults to user command objects");
            decimal betAmount = Constants.DEFAULT;
            int winningCamel = Constants.DEFAULT;
            char command = Constants.EMPTY_CHARACTER;            

            try
            {
                //splitting the input to arrive at data inputs.
                log.Info("Splitting the provided user input");
                var data = userInput.Split(Constants.SINGLE_SPACE);

                foreach (var input in data)
                    log.Info(string.Format("User inputs : {0}", input));

                //if the command is a bet...
                log.Info("Checking if the first input is integer");
                if (int.TryParse(data[0], out winningCamel))
                {
                    command = Constants.BET;

                    log.Info("Checking if the second input is number");
                    decimal.TryParse(data[1], out betAmount);               //set to decimal to throw appropriate validation message during input validation process. 
                    log.Info(string.Format("Bet placed on Camel : {0} with the bet amount : {1} ", winningCamel, betAmount));
                }
                else //for other commands like setting winner, restock and quit.
                {
                    log.Info("Checking if the first input is character");
                    command = char.Parse(data[0].ToLower());

                    //checking for character input followed by any other data..
                    if (data.Count() > 1 && !string.IsNullOrEmpty(data[1]))                    
                        int.TryParse(data[1], out winningCamel);

                    log.Info(string.Format("Input Command : {0}", command));
                    
                }

                //updating the user command objects with extracted data..
                userCommand.UserInputCommand = userInput;
                userCommand.CamelNumber = winningCamel;
                userCommand.BetAmount = betAmount;
                userCommand.Command = command;
            }
            catch(Exception)
            {
                log.Info(string.Format("Raising Invalid Command exception. Provided input doesnt match the defined input criteria."));
                throw new InvalidCommandException(userInput);
            }
            
        }
    }
}
