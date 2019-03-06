//---------------------------------------------------------------------------------
// <copyright file="PolishNotation" website="Patrikduch.com">
//     Copyright 2019 (c) Patrikduch.com
// </copyright>
// <author>Patrik Duch</author>
// Reverse polish notation implementation checker
//--------------------------------------------------------------------------------

namespace LLParsers.Arithmetic.Lexer
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PolishNotation
    {
        private static IEnumerable<string> RemoveEmptyElements(string[] inputStrings)
        {
            foreach (var inputString in inputStrings)
            {

                if (!inputString.Equals(""))
                {
                    yield return inputString;
                }
            }
        }


        public static bool IsParseable(string input)
        {
            // Number of brackets are not same
            if (input == null) return false;


            Stack<string> operatorsStack = new Stack<string>();
            Stack<string> operandsStack = new Stack<string>();


            var res = input.Split(' ');

            // Optimalize array

            res = RemoveEmptyElements(res).ToArray();



            // Processing operands and operators

            foreach (var i in res)
            {
                if (i == "+" || i == "-")
                {
                    operatorsStack.Push(i);
                }
                else
                {
                    operandsStack.Push(i);
                }

            }

            if (operandsStack.Count == 0 && operatorsStack.Count > 0) return false;

            // 3+3+ situation
            if (operandsStack.Count == operatorsStack.Count) return false;


            // Evaluation

            Stack<string> resultOperands = new Stack<string>();

            for (int i = 0; i < operatorsStack.Count; i++)
            {

                if (operandsStack.Count > 0)
                {
                    if (operandsStack.Count >= 1 && operandsStack.Count <= 1)
                    {
                        return false;
                    }

                    if (operandsStack.Count != 1)
                    {

                        try
                        {
                            int.TryParse(operandsStack.Pop(), out var x);
                            int.TryParse(operandsStack.Pop(), out var y);

                            // Delete top of stack with operators
                            operatorsStack.Pop();

                            int result = x + y;

                            resultOperands.Push(result.ToString());
                        }

                        catch (System.InvalidOperationException)
                        {

                            return false;
                        }

                    }
                    else
                    {
                        int.TryParse(operandsStack.Pop(), out int x);

                        resultOperands.Push(x.ToString());
                    }






                }
                else
                {
                    operandsStack.Push(operandsStack.ElementAtOrDefault(i));
                }

            }


            // If not popping is required
            if (operatorsStack.Count == 0 || operandsStack.Count > 0) return true;

            return operandsStack.Count == 0;



        }

        private static string CorrectStringFormat(string input)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '-' || input[i] == '+' || input[i] == '/')
                {
                    sb.Append(' ');
                    sb.Append(input[i]);
                    sb.Append(' ');
                    continue;
                }
                sb.Append(input[i]);
            }
            var result  = sb.ToString();

            return CheckParity(result) ? result : null;
        }




        public static string PostFixFormat(string input)
        {
            var res = DeleteBrackets(input);
            return CorrectStringFormat(new string(res.ToArray()));
        }


        private static bool CheckParity(string input)
        {
            var leftBraceCount = 0;
            var rightBraceCount = 0;

            foreach (var element in input)
            {
                switch (element)
                {
                    case '(':
                        leftBraceCount++;
                        break;
                    case ')':
                        rightBraceCount++;
                        break;
                }
            }

            return rightBraceCount == leftBraceCount;

        }


        private static IEnumerable<char> DeleteBrackets(string input)
        {
            if (CheckParity(input))
            {


                foreach (var t in input)
                {
                    switch (t)
                    {
                        case '(':
                        case ')':
                            continue;
                        default:
                            yield return t;
                            break;
                    }
                }
            }

           
        }




    }
}
