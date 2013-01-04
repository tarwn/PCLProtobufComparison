using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestCore
{
    public class Test
    {
        public string Name { get; set; }

        public Result Run(int itemCount, long dllSize)
        {

            var result = new Result()
            {
                TestName = Name,
                DTOCount = itemCount,
                DLLSize = dllSize
            };

            var startDate = DateTime.Now;
            var stream = new MemoryStream();
            var testData = SampleDTO.GenerateSamples(itemCount);
            var endDate = DateTime.Now;

            result.SetupTime = (endDate - startDate).TotalMilliseconds;

            startDate = DateTime.Now;
            SerializerUtility.Serialize(stream, testData);
            endDate = DateTime.Now;

            result.SerializeTime = (endDate - startDate).TotalMilliseconds;
            result.SerializedByteCount = stream.ToArray().Length;

            stream.Seek(0, SeekOrigin.Begin);
            startDate = DateTime.Now;
            var deData = SerializerUtility.Deserialize<SampleDTO>(stream);
            endDate = DateTime.Now;

            result.DeserializeTime = (endDate - startDate).TotalMilliseconds;

            return result;
        }
    }

    public class Result
    {
        public string TestName { get; set; }
        public int DTOCount { get; set; }
        public double SetupTime { get; set; }
        public double SerializeTime { get; set; }
        public double DeserializeTime { get; set; }
        public int SerializedByteCount { get; set; }
        public long DLLSize { get; set; }
    }
}
