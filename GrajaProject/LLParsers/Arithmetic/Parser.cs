using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringTools;

namespace LLParser
{
    public class Parser
    {
        static StringTokenizer st;
        public static String curr;

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

        public static int? init(StringTokenizer tokenizer)
        {

            st = tokenizer;

            next();

            return parseS();
        }

        #endregion


        #region Gramatika

        public static int? parseS()
        {
            int? x = parseT();
            return parseE(x);
        }

        public static int? parseT()
        {
            int? x = parseF();
            return parseT1(x);
        }

        public static int? parseE(int? input)
        {
            if (curr == "+")
            {
                next();
                int? y = parseT();
                return parseE(input + y);

            } else if(curr == "-")
            {
                next();
                int? y = parseT();
                return parseE(input - y);
            }

            else if (curr == ")" || curr == "$")
            {
                return input;
            }
            else
            {

                return input;

            }
        }

        public static int? parseF()
        {
            // F -> ( E ) | a
            if (curr == "(")
            {
                next();
                int? x = parseS();
                if (curr == ")")
                {
                    next();
                    return x;
                }
                else
                {
                    throw new Exception(") expected.");
                }
            }
            else try
                {
                    int? x = Int32.TryParse(curr, out var tempVal) ? tempVal : (int?)null;
                    next();
                    return x;
                }
                catch (Exception ex)
                {
                    //error("Number expected.");
                    //return null; // to make compiler happy

                    throw new Exception("Očekávalo se číslo");
                }
        }

        public static int? parseT1(int? input)
        {
            // T1 -> * F T1 | epsilon
            if (curr == "*")
            {
                next();
                int? y = parseF();
                return parseT1(input * y);

            }


            else if (curr == "/")
            {
                next();
                int? y = parseF();
                return parseT1(input / y);

            }

            else if (curr == "+" || curr == ")" || curr == "$" || curr == "-")
            {
                return input;
            }
            else
            {
                //error("Unexpected :" + curr);
                //return input; // to make compiler happy

                throw new Exception("Unexpected");
            }
        }


        #endregion




    }
}
