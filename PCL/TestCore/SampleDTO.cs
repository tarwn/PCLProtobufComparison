using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCore
{
    [ProtoContract]
    public class SampleDTO
    {
        [ProtoMember(1)]
        public string StringData { get; set; }

        [ProtoMember(2)]
        public int IntData { get; set; }

        [ProtoMember(3)]
        public DateTime DateData { get; set; }

        [ProtoMember(4)]
        public string StringData2 { get; set; }

        [ProtoMember(5)]
        public int IntData2 { get; set; }

        [ProtoMember(6)]
        public DateTime DateData2 { get; set; }

        public SampleDTO() { }

        public static List<SampleDTO> GenerateSamples(int number)
        {
            var result = new List<SampleDTO>();
            var sampleDate = DateTime.Now;

            for (int i = 0; i < number; i++)
                result.Add(new SampleDTO() { IntData = i, IntData2 = i + 1, DateData = sampleDate.AddHours(i), DateData2 = sampleDate.AddDays(i), StringData = Guid.NewGuid().ToString(), StringData2 = Guid.NewGuid().ToString()});

            return result;
        }
    }
}
