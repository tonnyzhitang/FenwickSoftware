using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FenwickSoftwareTechnicalTask
{
    public class CMD
    {
        //command statements elements
        private string[] Cmds;

        //commands list
        private List<Command> Appcmds = new List<Command>();

        public CMD() {
            //print welcome message
            Console.WriteLine("Welcome to Fenwick Software Technical Task");
            Console.WriteLine("Candidate: Tonny\n");

            //Initialise commands
            Command record = new CommandRecord("record", "Record\nSave one or more values using command:\nStats.exe record filepath value[value 2..value n]\n");
            Command summary = new CommandSummary("summary", "Summary\nPrint a summary of the values into the console using command:\nStats.exe summary filepath\n");
            Command help = new CommandHelp("help", "Help\nPrint a commands list with details using command:\nStats.exe help\n");

            //Add commands to list 
            Appcmds.Add(record);
            Appcmds.Add(summary);
            Appcmds.Add(help);

        }

        public void ConsoleLine() {

            Console.Write(">");
            //let user input cammand line
            string cmd = Console.ReadLine();

            //check empty input
            if (cmd.Equals(""))
            {
                ConsoleLine();
            }

            string[] commands = cmd.Split(new char[0]);

            //Check input have at least two statments
            if (commands.Length >= 2)
            {
                string commandName = commands[1].Replace(" ","");
                Command current = Appcmds.SingleOrDefault(c => c.CommandName == commandName);     
                //check command exsit
                if (current != null)
                {
                    //take actions
                    current.Action(ref cmd, ref Cmds, ref Appcmds);
                }
                else {
                    Console.WriteLine("No command found.");
                }
            }
            else {
                Console.WriteLine("No command found.");
            }

            ConsoleLine();

        }

    }
}
