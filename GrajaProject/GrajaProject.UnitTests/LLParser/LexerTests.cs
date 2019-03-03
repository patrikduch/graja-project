using System;
using System.Collections.Generic;
using LLParser;
using LLParser.Lexer;
using LLParsers.Arithmetic.Lexer;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace GrajaProject.UnitTests.LLParser
{
    [TestFixture()]
    public class LexerTests
    {
        private Analyze _analyze;


        [Test]
        public void TestMethod()
        {

            _analyze = new Analyze("3--81");

            Parser.Init(_analyze.Tokenizer);

            var result = Parser.Parse();


          

           










        }
    }
}
