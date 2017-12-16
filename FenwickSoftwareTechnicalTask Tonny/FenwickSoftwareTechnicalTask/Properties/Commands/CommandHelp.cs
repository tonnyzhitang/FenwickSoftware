using System;
using System.Collections.Generic;
using System.Text;

namespace FenwickSoftwareTechnicalTask
{
    public class CommandHelp : Command
    {
        public CommandHelp(string commandName, string commandDescription)
        :base(commandName, commandDescription)
        {

        }

        public override bool Action(ref string cmdline, ref string[] commands, ref List<Command> appCommands) {
            //general check command "Stats.exe" 
            if (CheckCommand(ref cmdline, ref commands) == false)
            {
                return false;
            }

            //print all the commans description in command list
            Console.WriteLine("+-----------------Command Helper------------------+\n");
            foreach (var cm in appCommands) {
                Console.WriteLine(cm.CommandDescription);
            }          
            return true;
        }


    }
}
