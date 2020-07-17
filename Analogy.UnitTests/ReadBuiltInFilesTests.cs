using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Analogy.UnitTests
{
    [TestClass]
    public class ReadBuiltInFilesTests
    {
        private CancellationTokenSource cancellationTokenSource;
        private MessageHandlerForTesting handler = new MessageHandlerForTesting();
       // [TestMethod]
        public  void TestWriteAndRead()
        {
            string fileName = "example.ajson";
            cancellationTokenSource = new CancellationTokenSource();
            FileProcessor fp = new FileProcessor(handler);
            
        }
    }
}
