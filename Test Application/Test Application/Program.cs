using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamelTraceTrack
{
    public partial class Program
    {
        static protected ILog log = LogManager.GetLogger("CamelRaceTrack");

        public static void Main(string[] args)
        {
            log.Info("******************** Starting Application *************************");
            InitializeApplication();                         //inititation..       
            
            #region Main
            while (true)
            {
                log.Info(">>>>>>>>>>>>>>>>> Requesting user input >>>>>>>>>>>>>>>");
                var userInput = Console.ReadLine();     //Accepting user input      
                log.Info(string.Format("Provided user input : {0}", userInput));

                UserCommand userCommand;                //maintaining object of the user inputs for easier logical navigation..                

                try
                {
                    ParseInput.ParseInputData(out userCommand, userInput); //Extract data from User inputs.                    
                    if(ValidateRequest(userCommand))
                        ProcessRequest(userCommand);
                }
                catch (Exception ex)
                {
                    //continue with the execution for any defined exception types..
                    if (ex is InvalidCommandException || ex is InvalidCamelException || ex is NoPayoutException || ex is InvalidBetException)
                        continue;
                    else
                    {
                        log.Error(string.Format("Exception in application. Please check the logged datapoints. \n" +
                                    "Exception details : {0}" +
                                    "Exception Stacktrace : {1}" ,ex.Message, ex.StackTrace));
                        Console.WriteLine(string.Format("Exception in Application :{0}", ex.Message));
                    }
                }
                log.Info("------------------- Completed processing user request -------------------");

            }

            #endregion

        }
        
    }
}
