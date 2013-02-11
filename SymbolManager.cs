using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFAssembler
{
    class SymbolManager
    {

        public SymbolManager()
        {
            for (int i = 0; i < 16;i++)
                symbols.Add("R" + i,i);
        }

        Dictionary<string, int> symbols = new Dictionary<string, int>()
        {
            {"SP",0},
            {"LCL",1},
            {"ARG",2},
            {"THIS",3},
            {"THAT",4},
            {"SCREEN",16384},
            {"KBD",24576}
        };
            

        int nextVariable = 16;


        public bool inTable(string symbol)
        {
            return symbols.ContainsKey(symbol);
        }

        public void addSymbol(string symbol)
        {
            symbols.Add(symbol, nextVariable++);
        }

        public void addSymbol(string symbol, int value)
        {
            symbols.Add(symbol,value);
        }

        public int getSymbol(string symbol)
        {
            return symbols[symbol];
        }

    }
}
