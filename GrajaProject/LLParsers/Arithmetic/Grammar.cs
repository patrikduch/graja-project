//---------------------------------------------------------------------------------
// <copyright file="Grammar" website="Patrikduch.com">
//     Copyright 2017 (c) Patrikduch.com
// </copyright>
// <author>Patrik Duch</author>
// Grammar rules for classification math expressions
//--------------------------------------------------------------------------------

using System;
using LLParser.Lexer;

namespace LLParsers.Arithmetic
{
    public class Grammar
    {

        /// <summary>
        /// Indicator of parser state
        /// </summary>
        public static bool Parseable = false;

        /// <summary>
        /// Reference for lexer analysis
        /// </summary>
        private static Analyze _analyze;

        /// <summary>
        /// Auxiliary variable for monitoring current state
        /// </summary>
        private static string _actual;

        /// <summary>
        ///  S->NON
        /// </summary>
        /// <param name="analyze"></param>
        public static void S(Analyze analyze)
        {
            _analyze = analyze;

            
            var tokens = _analyze.Tokenizer.Tokens;

            _actual = _analyze.Tokenizer.nextToken();
            int? res = 0;

            while (_actual != null)
            {
                if (_actual == "$")
                {
                    Parseable = true;
                    break; // End of the loop
                   
                }

                N(_actual);

                if (_analyze.Tokenizer.HasMoreTokens)
                {
                    _actual = _analyze.Tokenizer.nextToken();
                }
            }
        }


        private static void N(string input)
        {

            char c = Convert.ToChar(input);

            if (c == '(')
            {
                P1();
            }

            if (c == ')')
            {
                P2();
            }

            if (char.IsLetter(c))
            {
                T();
            }

            if (c == '+' || c == '-')
            {
                O();
            }

            if (char.IsDigit(c))
            {
                int.TryParse(input, out int val);
            }
        }

        /// <summary>
        /// Text is not allowed
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        private static int? T()
        {
            return null;
        }

        private static void O()
        {
            char c = Convert.ToChar(_analyze.Tokenizer.nextToken());

            if (char.IsDigit(c))
            {
                int.TryParse(c.ToString(), out int val);
                // return val;}}
            }

            // return null;
        }

        /// <summary>
        /// Start bracket grammar rule
        /// </summary>
        /// <returns></returns>
        private static void P1()
        {
            char c = Convert.ToChar(_analyze.Tokenizer.nextToken());

            if (char.IsDigit(c))
            {
                _actual = c.ToString();

                N(_actual);
            }
        }

        /// <summary>
        /// End bracket grammar rule
        /// </summary>
        /// <returns></returns>
        private static void P2()
        {
            var res = _analyze.Tokenizer.nextToken();

            if (res.Equals("$"))
            {
                Parseable = true;
                _actual = "$";
                return;

            }

            O();
        }

    }
}
