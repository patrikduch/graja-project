namespace LLParser
{
    using System;
    using System.Collections.Generic;
    using LLParsers.Arithmetic.Lexer;
    using StringTools;

    public class Parser
    {
        static StringTokenizer st;

        /// <summary>
        /// Indicator of parser state
        /// </summary>
        public static bool Parseable = false;

        #region Inicializace parsování
        public static void Init(StringTokenizer tokenizer)
        {
            st = tokenizer;
        }

        #endregion

        public static bool Parse(string input)
        {
            String res = string.Empty;
            try
            {
                res = PolishNotation.PostFixFormat(input);
            }
            catch (InvalidOperationException)
            {
                return false;
            }

            

            Stack<char> stack = new Stack<char>();

            try
            {

                int bracketsCount = 0;

                foreach (var re in res)
                {

                    if (re.ToString() == "(" || re.ToString() == ")")
                    {
                        bracketsCount++;

                    }

                    if (re.ToString() == "+" || re.ToString() == "-" || re.ToString() == "/"|| re.ToString() == "*")
                    {
                        stack.Pop();
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(re);
                    }
                }


                if (bracketsCount % 2 != 0)
                {
                    return false;
                }

                return true;


            }
            catch (InvalidOperationException)
            {
                return false;

            }

        }

        

    }
}
