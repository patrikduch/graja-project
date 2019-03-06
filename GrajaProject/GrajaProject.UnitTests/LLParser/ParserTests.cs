//---------------------------------------------------------------------------------
// <copyright file="LexerTests" website="Patrikduch.com">
//     Copyright 2017 (c) Patrikduch.com
// </copyright>
// <author>Patrik Duch</author>
// Unit test for parser functionality
//--------------------------------------------------------------------------------

namespace GrajaProject.UnitTests.LLParser
{
    using LLParsers.Arithmetic.Lexer;
    using NUnit.Framework;

    [TestFixture()]
    public class ParserTests
    {
        [Test]
        public void TestInputForOnlySingleNumber()
        {
            var res = PolishNotation.PostFixFormat("3");

            var result = PolishNotation.IsParseable(res);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void TestInputForOnlySingleNumberWithSingleOperator()
        {
            var res = PolishNotation.PostFixFormat("3+");

            var result = PolishNotation.IsParseable(res);

            Assert.AreEqual(false, result);
        }


        [Test]
        public void TestInputForOnlySingleNumberWithSingleOperatorWithBrace()
        {
            var res = PolishNotation.PostFixFormat("(3+");

            var result = PolishNotation.IsParseable(res);

            Assert.AreEqual(false, result);
        }


        [Test]
        public void TestInputForOnlySingleNumberInBrackets()
        {

            var res = PolishNotation.PostFixFormat("(3)");

            var result = PolishNotation.IsParseable(res);

            Assert.AreEqual(true, result);

        }



        [Test]
        public void TestInputForAdditionTwoNumbers()
        {

            var res = PolishNotation.PostFixFormat("3+3");

            var result = PolishNotation.IsParseable(res);

            Assert.AreEqual(true, result);


        }


        [Test]
        public void TestInputForAdditionTwoNumbersInBrackets()
        {
            var res = PolishNotation.PostFixFormat("(3+3)");

            var result = PolishNotation.IsParseable(res);

            Assert.AreEqual(true, result);

        }


        [Test]
        public void TestInputForAdditionTwoNumbersInBracketsWithExtraOperator()
        {
            var res = PolishNotation.PostFixFormat("(5+2)+3");

            var result = PolishNotation.IsParseable(res);

            Assert.AreEqual(true, result);

        }


        [Test]
        public void TestInputForOperatorInParentheses()
        {

            var res = PolishNotation.PostFixFormat("(+)");

            var result = PolishNotation.IsParseable(res);

            Assert.AreEqual(false, result);


   
        }


        [Test]
        public void TestInputForMultipleSameOperator()
        {
            string testString = "3--";
            var res = PolishNotation.PostFixFormat("3--");

            var result = PolishNotation.IsParseable(res);
            Assert.AreEqual(false, result);

        }


        [Test]
        public void TestInputForOperationOnToParanthese()
        {

            var res = PolishNotation.PostFixFormat("3-(33)-");

            var result = PolishNotation.IsParseable(res);

            Assert.AreEqual(false, result);


        }


        [Test]
        public void TestInputForMultipleSameOperations()
        {

            var res = PolishNotation.PostFixFormat("(3+3)++");

            var result = PolishNotation.IsParseable(res);

            Assert.AreEqual(false, result);


        }

        [Test]
        public void TestInputForBiggerLength()
        {

            var res = PolishNotation.PostFixFormat("2+3+3");

            var result = PolishNotation.IsParseable(res);

            Assert.AreEqual(true, result);


        }

        [Test]
        public void TestInputForMoreBiggerLength()
        {

            var res = PolishNotation.PostFixFormat("3+3+3+3");

            var result = PolishNotation.IsParseable(res);

            Assert.AreEqual(true, result);


        }



    }
}
