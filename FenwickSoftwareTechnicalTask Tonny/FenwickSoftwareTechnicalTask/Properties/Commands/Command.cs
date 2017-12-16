using System;
using System.Collections.Generic;
using System.Text;

namespace FenwickSoftwareTechnicalTask
{
    public abstract class Command
    {
        //important command name is the keywrord using in command line
        public string CommandName;
        public string CommandDescription;
        private string Filepath = "";

        public Command(string commandName, string commandDescription) {
            CommandName = commandName;
            CommandDescription = commandDescription;
        }

        public abstract bool Action(ref string cmdline, ref string[] commands, ref List<Command> appCommands);

        public bool CheckCommand(ref string cmdline, ref string[] commands)
        {
            //Split cammand line
            commands = cmdline.Split(new char[0]);

            //stats, action ,Filepath check
            try
            {
                if (!commands[0].Equals("Stats.exe"))
                {
                    CommandNotFound();
                }

                if (commands.Length >= 3)
                {
                    Filepath = commands[2];
                }
                return true;
            }
            catch (Exception)
            {
                CommandNotFound();
                return false;
            }
        }

        //Check Filepath is valid
        //File format must be txt format file
        public bool CheckFilepath() {
            if (Filepath.Equals("") || !Filepath.EndsWith(".txt") || Filepath.Length < 4)
            {
                Console.WriteLine("Filepath not input or wrong format.");
                Console.WriteLine("File format must be txt.");
                CommandNotice();
                return false;
            }
            return true;
        }

        //When command not found
        public void CommandNotFound() {
            Console.WriteLine("No command found.");
        }

        //When user input invalid command, give a notice 
        public void CommandNotice() {
            Console.WriteLine("Use command 'Stats.exe help' to get details.");
        }

    }
}
