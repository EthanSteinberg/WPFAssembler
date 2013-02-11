using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFAssembler
{
    class Parser
    {
        string text;
        List<string> linesOfText = new List<string>();
        SymbolManager symbols = new SymbolManager();



        public Parser(string textToParse)
        {
            text = textToParse;
            populateLinesOfText();
        }

        private void populateLinesOfText()
        {
            foreach (string line in text.Split(new string[] {Environment.NewLine},StringSplitOptions.None))
            {
                string processedLine = line;
                

                int positionOfFirstComment = line.IndexOf("//");
                if (positionOfFirstComment != -1)
                    processedLine = line.Substring(0, positionOfFirstComment);


                processedLine = processedLine.Trim();
                if (processedLine.Length != 0)
                    linesOfText.Add(processedLine);

            }
        }

        public string parse()
        {
            System.Console.WriteLine("Start at " + DateTime.Now);
            int location = 0;
            foreach (string line in linesOfText)
            {
                if (line[0] == '(')
                {
                    symbols.addSymbol(line.Substring(1, line.Length - 2), location);
                }
                else
                    location++;
            }

            System.Console.WriteLine("Phase two at " + DateTime.Now);

            StringBuilder result = new StringBuilder();
            foreach (string line in linesOfText)
            {
                
                if (line[0] != '(')
                {
                    result.AppendLine(Command.getBinary(line,symbols));
                   
                }
            }
            System.Console.WriteLine("Done at " + DateTime.Now);

            return result.ToString();
        }




        

    }
}
