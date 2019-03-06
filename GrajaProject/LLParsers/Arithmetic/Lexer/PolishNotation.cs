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
        private static bool _isParseable;

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

            var operatorsStack = new Stack<string>();
            var operandsStack = new Stack<string>();

            var res = input.Split(' ');

            // Optimalize array

            res = RemoveEmptyElements(res).ToArray();

            // Processing operands and operators

            foreach (var i in res)
            {
                if (i == "+" || i == "-" || i == "*" || i == "/")
                {
                    operatorsStack.Push(i);
                }
                else
                {
                    operandsStack.Push(i);
                }

            }

            // Parser process
            Parse(operandsStack, operatorsStack);

            return _isParseable;
        }

        private static void Parse(Stack<string> first, Stack<string> second)
        {

            if (first.Count == 1 && second.Count == 0)
            {
                _isParseable = true;
                return;
            }

            while (second.Count != 0)
            {
                if (first.Count <= 1)
                {
                    _isParseable = false;
                    return;
                }

                // Invalid set of operands and operators
                if (first.Count == 0 && second.Count != 0)
                {
                    _isParseable = false;
                    return;
                }

                if (first.Count == 0) break;

                int.TryParse(first.Pop(), out var x);

                if (first.Count != 0)
                {
                    int.TryParse(first.Pop(), out var y);

                    if (first.Count == 0)
                    {
                        // Delete operator
                        second.Pop();
                        continue; // Next iteration
                    }

                    first.Push(y.ToString());
                }

                // Delete operator
                second.Pop();
            }

            _isParseable = true;
        }

        private static string CorrectStringFormat(string input)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '-' || input[i] == '+' || input[i] == '/' || input[i] == '*')
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

            var enumerable= res as char[] ?? res.ToArray();
            return CorrectStringFormat(new string(enumerable.ToArray())).Equals("") ? null : CorrectStringFormat(new string(enumerable.ToArray()));
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
            if (!CheckParity(input)) yield break;
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
