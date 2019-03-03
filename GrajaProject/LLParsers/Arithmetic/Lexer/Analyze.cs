using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringTools;

namespace LLParser.Lexer
{
    public class Analyze
    {
        private String input;
        private StringTokenizer tokenizer;
        private String curr;

        public Analyze(String input)
        {
            this.input = toTokenizable(input);
            Tokenizer = new StringTokenizer(this.input);            
        }


        #region Tokenizace vstupu 

        private String toTokenizable(String input)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var i in input)
            {
                if (i == '+')
                {
                    stringBuilder.Append(" ");
                }
                stringBuilder.Append(i);
            }

            stringBuilder.Append("$"); // Signalizace ukončení vstupu

            return stringBuilder.ToString();
        }
        #endregion

        public string Input { get => input; set => input = value; }
        public StringTokenizer Tokenizer { get => tokenizer; set => tokenizer = value; }
    }
}
