using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Analogy.UnitTests
{
    [TestClass]
    public class InterpreterTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            string s = "(13hh5)&(4)|(9)";
            var interpreter=new InterpreterParser();
            var result = InterpreterParser.Lex(s);
            var res = InterpreterParser.Parse(result);
        }
    }
}
