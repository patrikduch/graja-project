using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LLParsers.Arithmetic.Lexer;
using StringTools;

namespace LLParser
{
    public class Parser
    {
        static StringTokenizer st;
        public static String curr;

        public static bool IsInputValid { get; set; }


        





        #region Přesun na další token
        public static void next()
        {
            try
            {
                curr = st.nextToken();
            }
            catch (Exception e)
            {
                curr = null;
            }
        }
        #endregion


        #region Inicializace parsování

        public static void Init(StringTokenizer tokenizer)
        {

            st = tokenizer;


           



        }


        

        public static bool Parse()
        {

            
            var res = PolishNotation.PostFixFormat(string.Join(" ", st.Tokens));

            Stack<char> stack = new Stack<char>();

            try
            {
                foreach (var re in res)
                {
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

                return true;


            }
            catch (InvalidOperationException)
            {
                return false;

            }

        }

        #endregion


       



    }
}
