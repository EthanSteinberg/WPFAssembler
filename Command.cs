using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Text.RegularExpressions;

namespace WPFAssembler
{
    class Command
    {

        public enum Type
        {
            A_COMMAND,
            C_COMMAND
        }

        Type t;
        string text;
        int value;

        string dest;
        string cmp;
        string jumpInstructions;


        static string regularExpression = @"^((?<destination>[DMA]+)=)?(?<comp>[^;]+)(;(?<jmp>\w+))?";
        static Regex regexMatch = new Regex(regularExpression);


        public Command(string text, SymbolManager symbols, Type t)
        {
           
            if (t == Type.A_COMMAND)
            {
               
            }
            else if (t == Type.C_COMMAND)
            { }
        }



        static public Command getCommand(string text, SymbolManager symbols)
        {
            if (text[0] == '@')
                return new Command(text, symbols,Type.A_COMMAND);
            else if (text[0] == '(')
                return null;
            else
                return new Command(text, symbols,Type.C_COMMAND);

        }


        public static string getBinary(string text, SymbolManager symbols)
        {
            Type t;
            if (text[0] == '@')
                t = Type.A_COMMAND;
            else
                t = Type.C_COMMAND;
            switch (t)
            {
                case Type.C_COMMAND:
                    {
                        Match m = regexMatch.Match(text);

                        string dest = m.Groups["destination"].Value;
                        string cmp = m.Groups["comp"].Value;
                        string jumpInstructions = m.Groups["jmp"].Value;

                        return "111" + Code.getCmp(cmp) + Code.getDst(dest) + Code.getJmp(jumpInstructions);
                    }
                case Type.A_COMMAND:
                    {
                        string valueOrSymbol = text.Substring(1);
                        int value;
                        if (Char.IsNumber(valueOrSymbol[0]))
                            value = int.Parse(valueOrSymbol);
                        else
                        {
                            if (!symbols.inTable(valueOrSymbol))
                                symbols.addSymbol(valueOrSymbol);
                            value = symbols.getSymbol(valueOrSymbol);
                        }
                        return "0" + Code.toBinary(value);
                    }
                default:
                    throw new NotImplementedException();
            }
        }

    }
}
