using System;
using System.Collections.Generic;
using System.Text;

namespace FenwickSoftwareTechnicalTask
{
    public class CommandRecord : Command
    {
        private string File_content = "";
        public CommandRecord(string commandName, string commandDescription)
        :base(commandName, commandDescription)
        {

        }

        public override bool Action(ref string cmdline, ref string[] commands, ref List<Command> appCommands) {
            //general check command "Stats.exe" and check Filepath validation
            if (CheckCommand(ref cmdline, ref commands) == false || CheckFilepath() == false) {
                return false;
            }
            
            try
            {
                for (int i = 3; i < commands.Length; i++)
                {
                    //Remove any mistake from user's input such as 42.00000, 4. and 004.2
                    //Add numbers in to content, later write into text file
                    File_content += Double.Parse(commands[i]).ToString() + " ";
                }
                
            }
            catch (Exception)
            {
                //Print message for miss imput numbers
                Console.WriteLine("Please input numbers to record.");
                CommandNotice();
                return false;
            }

            //Write content into a file
            FileOperation fp = new FileOperation(commands[2]);
            fp.WriteContent(File_content);
            //clean cuurent content
            File_content = "";
            return true;
        }

        
    }
}
