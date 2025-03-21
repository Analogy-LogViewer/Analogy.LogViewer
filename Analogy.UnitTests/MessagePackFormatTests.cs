﻿using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.LogLoaders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Analogy.UnitTests
{
    [TestClass]
    public class MessagePackFormatTests
    {
        private CancellationTokenSource cancellationTokenSource;
        [TestMethod]
        public async Task TestWriteAndRead()
        {
            string fileName = "test.bin";
            cancellationTokenSource = new CancellationTokenSource();
            AnalogyMessagePackFormat msgPack = new AnalogyMessagePackFormat();
            List<IAnalogyLogMessage> originals = new List<IAnalogyLogMessage>
            {
                new AnalogyLogMessage("test1", AnalogyLogLevel.Critical, AnalogyLogClass.General, "test"),
                new AnalogyLogMessage("test2", AnalogyLogLevel.Error, AnalogyLogClass.General, "test"),
            };
            await msgPack.Save(originals, fileName);
            Assert.IsTrue(File.Exists(fileName));
            MessageHandlerForTesting handler = new MessageHandlerForTesting();
            var msg = (await msgPack.ReadFromFile(fileName, cancellationTokenSource.Token, handler)).ToList();
            Assert.IsTrue(msg.Count == 2);
            Assert.IsTrue(msg.First().Level == AnalogyLogLevel.Critical);
            Assert.IsTrue(msg.Skip(1).First().Text == "test2");
            File.Delete(fileName);
        }
    }
}