//---------------------------------------------------------------------------------
// <copyright file="PolishNotation" website="Patrikduch.com">
//     Copyright 2019 (c) Patrikduch.com
// </copyright>
// <author>Patrik Duch</author>
// Reverse polish notation implementation checker
//--------------------------------------------------------------------------------

using StringManipulation;

namespace LLParsers.Arithmetic.Parser
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Implementation of Polish reversed notation
    /// </summary>
    public class PolishNotation
    {
        #region Fields 
        private static bool _isParseable;
        #endregion

        #region Methods
        /// <summary>
        /// Checking the parseable status of specific string representation
        /// </summary>
        /// <param name="input">String that will be tested</param>
        /// <returns></returns>
        public static bool IsParseable(string input)
        {
            // Number of brackets are not same
            if (input == null) return false;

            var operatorsStack = new Stack<string>();
            var operandsStack = new Stack<string>();

            var res = input.Split(' ');

            // Optimalize array

            res = StringHelper.RemoveEmptyElements(res).ToArray();

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
            ParseProcess(operandsStack, operatorsStack);

            return _isParseable;
        }

        /// <summary>
        /// Parsing process that save its status to the private field
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        private static void ParseProcess(Stack<string> first, Stack<string> second)
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


        /// <summary>
        /// Transform string input to the correct format
        /// </summary>
        /// <param name="input">String input</param>
        /// <returns></returns>
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
            var result = sb.ToString();

            return CheckParity(result) ? result : null;
        }

        /// <summary>
        /// Transformation to the PostFix from Infix format
        /// </summary>
        /// <param name="input">String in infix format</param>
        /// <returns></returns>
        public static string PostFixFormat(string input)
        {
            var res = DeleteBrackets(input);

            var enumerable = res as char[] ?? res.ToArray();
            return CorrectStringFormat(new string(enumerable.ToArray())).Equals("") ? null : CorrectStringFormat(new string(enumerable.ToArray()));
        }

        /// <summary>
        /// Checker of bracket parity
        /// </summary>
        /// <param name="input">String which will be tested</param>
        /// <returns></returns>
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

        /// <summary>
        /// Removal of brackets from string inputString if its parity is met
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        private static IEnumerable<char> DeleteBrackets(string inputString)
        {
            if (!CheckParity(inputString)) yield break;
            foreach (var element in inputString)
            {
                switch (element)
                {
                    case '(':
                    case ')':
                        continue;
                    default:
                        yield return element;
                        break;
                }
            }


        }


        #endregion
    }
}
