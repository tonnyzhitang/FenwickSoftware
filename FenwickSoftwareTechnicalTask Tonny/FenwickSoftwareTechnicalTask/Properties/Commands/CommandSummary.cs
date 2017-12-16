using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FenwickSoftwareTechnicalTask
{
    public class CommandSummary : Command
    {
        //numbers from file will be added into this list
        private List<double> Numbers;

        public CommandSummary(string commandName, string commandDescription)
        : base(commandName, commandDescription)
        {

        }

        public override bool Action(ref string cmdline, ref string[] commands, ref List<Command> appCommands)
        {
            //general check command "Stats.exe" and check Filepath validation
            if (CheckCommand(ref cmdline, ref commands) == false || CheckFilepath() == false)
            {
                return false;
            }

            //Read content from file
            FileOperation fp = new FileOperation(commands[2]);
            string[] read_num;
            string content = "";
            try
            {
                //Get message when the content is empty
                content = fp.ReadContent();
                if (content.Equals(""))
                {
                    Console.WriteLine("No numbers in the file!\n");
                    return false;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            //initialise list
            Numbers = new List<double>();
            //Split content to numbers
            read_num = content.Split(new char[0]);
            //transfer the numbers to double type and add the numbers into List for calculation (min, max, avg)
            for (int i = 0; i < read_num.Length; i++)
            {
                if (!read_num[i].Replace("  ", "").Equals(""))
                {
                    Numbers.Add(Double.Parse(read_num[i]));
                }
            }

            //Print Summary Table
            PrintSummaryTable();
            return true;
        }

        //Print Summary Table
        private void PrintSummaryTable()
        {
            Console.WriteLine("+--------------+------+");
            Console.WriteLine(String.Format("| # of Entries |{0,3}   |", Numbers.Count()));
            Console.WriteLine(String.Format("| Min. value   |{0,5:F1} |", Numbers.Min()));
            Console.WriteLine(String.Format("| Max. value   |{0,5:F1} |", Numbers.Max()));
            Console.WriteLine(String.Format("| Avg. value   |{0,5:F1} |", Numbers.Average()));
            Console.WriteLine("+--------------+------+\n");
        }

    }
}
