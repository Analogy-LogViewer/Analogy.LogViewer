using Analogy.Interfaces;
using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Analogy.Implementation.KafkaProvider
{
    public class AnalogyKafkaSerializer : ISerializer<AnalogyLogMessage>, IDeserializer<AnalogyLogMessage>
    {
        private BinaryFormatter _bFormatter;
        public AnalogyKafkaSerializer()
        {
            _bFormatter = new BinaryFormatter();
        }

        public AnalogyLogMessage Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            using (var m = new MemoryStream())
            {
                m.Write(data.ToArray(), 0, data.Length);
                m.Position = 0;
                return (AnalogyLogMessage)_bFormatter.Deserialize(m);
            }
        }
        public byte[] Serialize(AnalogyLogMessage data, SerializationContext context)
        {
            using (var m = new MemoryStream())
            {
                _bFormatter.Serialize(m, data);
                m.Position = 0;
                return m.ToArray();
            }

        }
    }
}
