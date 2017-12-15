using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FenwickSoftwareTechnicalTask
{
    class Command
    {
        //store numbers values
        private List<double> Numbers;
        private string[] Cmds; 
        private string Filepath = "";
        private string Stats = ""; 
        private string Action = ""; 
        private string File_content = ""; 

        public Command() {
            //initialise numbers list
            Numbers = new List<double>();
            //print welcome message
            Console.WriteLine("Welcome to Fenwick Software Technical Task");
            Console.WriteLine("Candidate: Tonny\n");
        }

        public void ConsoleLine() {

            Console.Write(">");
            //user input cammand line
            string cmd = Console.ReadLine();

            //check empty input
            if (cmd.Equals(""))
            {
                ConsoleLine();
            }

            //Split cammand line
            Cmds = cmd.Split(new char[0]);

            //stats, action ,Filepath check
            try
            {
                Stats = Cmds[0];
                if (!Stats.Equals("Stats.exe"))
                {
                    CommandNotFound();
                }

                Action = Cmds[1];

                if (Cmds.Length >= 3) {
                    Filepath = Cmds[2];
                }
            }
            catch (Exception)
            {
                CommandNotFound();
            }

            switch (Action)
            {
                case "record":
                    Record();
                    break;
                case "summary":
                    Summary();
                    break;
                case "help":
                    Help();
                    break;
                default:
                    CommandNotFound();
                    break;
            }
        }

        //Record command
        private void Record() {
            //check Filepath validation
            CheckFilepath();

            try
            {
                for (int i = 3; i< Cmds.Length; i++) {
                    //Remove any mistake from user's input such as 42.00000
                    File_content += Double.Parse(Cmds[i]).ToString() + " ";
                }
            }
            catch (Exception)
            {
                //Print message for miss imput numbers
                Console.WriteLine("Please input numbers to record.");
                CommandNotice();
            }

            //Write content into a file
            FileOperation fp = new FileOperation(Filepath);
            fp.WriteContent(File_content);
            File_content = "";
            ConsoleLine();
        }

        //Summary command
        private void Summary()
        {
            //check Filepath validation
            CheckFilepath();

            //Read content from file
            FileOperation fp = new FileOperation(Filepath);
            string[] read_num;
            string content = "";
            try
            {
                //Get message when the content is empty
                content = fp.ReadContent();
                if (content.Equals("")) {
                    Console.WriteLine("No numbers in the file!\n");
                    ConsoleLine();
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                ConsoleLine();
            }

            Numbers = new List<double>();
            read_num = content.Split(new char[0]);
            //Update the numbers into List for calculation (min, max, avg)
            for (int i = 0; i< read_num.Length; i++) {
                if (!read_num[i].Replace("  ", "").Equals("")) {
                    Numbers.Add(Double.Parse(read_num[i]));
                }            
            }

            //Print Summary Table
            PrintSummaryTable();
            ConsoleLine();
        }

        //Help command
        private void Help()
        {
            Console.WriteLine("+-----------------Command Helper------------------+\n");
            Console.WriteLine("Record\nSave one or more values using command:\nStats.exe record filepath value[value 2..value n]\n");
            Console.WriteLine("Summary\nPrint a summary of the values into the console using command:\nStats.exe summary filepath\n");
            ConsoleLine();
        }

        //When command not found
        private void CommandNotFound() {
            Console.WriteLine("No command found.");
            CommandNotice();
        }

        //When user input invalid command
        private void CommandNotice() {
            Console.WriteLine("Use command 'Stats.exe help' to get details.\n");
            ConsoleLine();
        }

        //Check Filepath is valid
        private void CheckFilepath() {
            if (Filepath.Equals("") || !Filepath.EndsWith(".txt") || Filepath.Length < 4)
            {
                Console.WriteLine("Filepath not input or wrong format.");
                Console.WriteLine("File format must be txt.");
                CommandNotice();
            }
        }

        //Print Summary Table
        private void PrintSummaryTable() {
            Console.WriteLine("+--------------+------+");
            Console.WriteLine(String.Format("| # of Entries |{0,3}   |", Numbers.Count()));
            Console.WriteLine(String.Format("| Min. value   |{0,5:F1} |", Numbers.Min()));
            Console.WriteLine(String.Format("| Max. value   |{0,5:F1} |", Numbers.Max()));
            Console.WriteLine(String.Format("| Avg. value   |{0,5:F1} |", Numbers.Average()));
            Console.WriteLine("+--------------+------+\n");
        }

    }
}
