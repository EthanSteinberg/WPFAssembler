using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFAssembler
{
    static class Code
    {

        static Dictionary<string, string> cmpDict = new Dictionary<string, string>()
        {
            {"0",  "101010"},
            {"1",  "111111"},
            {"-1", "111010"},
            {"D",  "001100"},
            {"A",  "110000"},
            {"!D", "001101"},
            {"!A", "110001"},
            {"-D", "001111"},
            {"-A", "110011"},
            {"D+1","011111"},
            {"A+1","110111"},
            {"D-1","001110"},
            {"A-1","110010"},
            {"D+A","000010"},
            {"D-A","010011"},
            {"A-D","000111"},
            {"D&A","000000"},
            {"D|A","010101"},


        };

        static Dictionary<string, string> jmpDict = new Dictionary<string, string>()
        {
            {"",     "000"},
            {"JGT",  "001"},
            {"JEQ",  "010"},
            {"JGE",  "011"},
            {"JLT",  "100"},
            {"JNE",  "101"},
            {"JLE",  "110"},
            {"JMP",  "111"},
        };

         static Dictionary<string, string> dstDict = new Dictionary<string, string>()
        {
            {"",     "000"},
            {"M",    "001"},
            {"D",    "010"},
            {"A",    "100"},
        };


        public static string getCmp(string cmp)
        {
            
            bool a = cmp.Contains('M');

            return (a?"1":"0") + cmpDict[cmp.Replace('M','A')];
        }

        public static string getJmp(string jmp)
        {
          
                return jmpDict[jmp];
        }

        public static string getDst(string dst)
        {

            string result ="";
            if (dst.Contains("A"))
                result += "1";
            else
                result += "0";
            if (dst.Contains("D"))
                result += "1";
            else
                result += "0";
            if (dst.Contains("M"))
                result += "1";
            else
                result += "0";

            return result;

        }

        public static string toBinary(int number)
        {
            string result = "";
            for (int i = 14; i >= 0; i--)
            {
                int digit = (number >> i) % 2;
                result += digit;
            }
            return result;
        }



    }
}
