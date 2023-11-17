using Analogy.Common.DataTypes;
using Analogy.Common.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Analogy.UnitTests
{
    [TestClass]
    public class ReadBuiltInFilesTests
    {
        private CancellationTokenSource cancellationTokenSource;
        private MessageHandlerForTesting handler = new MessageHandlerForTesting();
        // [TestMethod]
        public void TestWriteAndRead()
        {
            string fileName = "example.ajson";
            cancellationTokenSource = new CancellationTokenSource();
            FileProcessor fp = new FileProcessor(new DefaultUserSettingsManager(), handler, new FileProcessingManager(), new EmptyAnalogyLogger());

        }
    }
}