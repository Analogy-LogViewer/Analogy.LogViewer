using System;
using System.Collections.Generic;
using System.Text;
using Analogy.Interfaces;

namespace Analogy.Implementation.KafkaProvider
{
    public class AnalogyKafkaLogMessageArgs : EventArgs
    {
        public AnalogyLogMessage Message { get; private set; }

        public AnalogyKafkaLogMessageArgs(AnalogyLogMessage msg)
        {
            Message = msg;
        }
    }
}
