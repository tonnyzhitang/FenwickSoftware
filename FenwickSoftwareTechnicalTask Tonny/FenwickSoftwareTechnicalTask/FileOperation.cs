using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FenwickSoftwareTechnicalTask
{
    class FileOperation
    {
        private string Filepath; 

        public FileOperation(string filepath) {
            Filepath = filepath;
        }

        //Add or write content to the file
        public void WriteContent(string content) {

            //Check file exist. If exist, append content to file, otherwise create a new file and write content
            if (File.Exists(Filepath))
            {
                // Append the content to the file.
                using (StreamWriter sw = File.AppendText(Filepath))
                {
                    sw.Write(content);
                }
            }
            else {
                // Write the content to a file.
                using (StreamWriter file = new StreamWriter(Filepath))
                {
                    file.Write(content);
                }
            }
                    
        }

        //Read content from a file
        public string ReadContent() 
        {
            string content = "";
            string line;
            //Check file exist. if not exist throw an exception
            if (!File.Exists(Filepath))
            {
                throw new System.ArgumentException("File not found\n");
            }

            //read content from a file
            using (StreamReader sw = new StreamReader(Filepath))
            {
                while ((line = sw.ReadLine()) != null)
                {
                    content += line.ToString();
                }
            }
            return content;
        }

    }
}
