//---------------------------------------------------------------------------------
// <copyright file="LexerTests" website="Patrikduch.com">
//     Copyright 2017 (c) Patrikduch.com
// </copyright>
// <author>Patrik Duch</author>
// Unit test for lexer functionality
//--------------------------------------------------------------------------------

using System;
using LLParser;
using LLParser.Lexer;
using LLParsers.Arithmetic;

namespace GrajaProject.UnitTests.LLParser
{
    using NUnit.Framework;

    [TestFixture()]
    public class LexerTests
    {
        private Analyze _analyze;

        // Test needs to be sucessfull
        [Test]
        public void TestInputForOnlySingleNumber()
        {
            string testString = "(3-3)";
            _analyze = new Analyze(testString);

            Grammar.S(_analyze);

            var res = Grammar.Parseable;

        }

        
        
    }
}
