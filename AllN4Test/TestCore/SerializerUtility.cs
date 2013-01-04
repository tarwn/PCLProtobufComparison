using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestCore
{
    public class SerializerUtility
    {

        public static void Serialize<T>(Stream stream, T entity)
        {
            Serializer.Serialize(stream, entity);
        }

        public static T Deserialize<T>(Stream stream)
        {
            return Serializer.Deserialize<T>(stream);
        }

    }
}
