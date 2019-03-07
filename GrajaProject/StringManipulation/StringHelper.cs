//---------------------------------------------------------------------------------
// <copyright file="StringHelper" website="Patrikduch.com">
//     Copyright 2019 (c) Patrikduch.com
// </copyright>
// <author>Patrik Duch</author>
// Helper for string manipulations
//--------------------------------------------------------------------------------
namespace StringManipulation
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Helper for string manipulations
    /// </summary>
    public class StringHelper
    {
        public static IEnumerable<string> RemoveEmptyElements(string[] inputStrings)
        {
            if (inputStrings.Length == 0)
                throw new ArgumentException("Value cannot be an empty collection.", nameof(inputStrings));
            foreach (var inputString in inputStrings)
            {

                if (!inputString.Equals(""))
                {
                    yield return inputString;
                }
            }
        }

    }
}
