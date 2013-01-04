using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ALLPCLLocalProtobuf
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new TestCore.Test() { Name = "All PCL w/ Local Protobuf Test" };
            var results = new List<TestCore.Result>();
            for (int i = 0; i < 5; i++)
                results.Add(test.Run(1000000, new FileInfo("protobuf-net.dll").Length));

            string columns = "Name,DTO Count,Setup,Serialize,Bytes,Deserialize,DLLSize\n";
            string data = String.Join("\n", results.Select(result => String.Format("\"{0}\",{1},{2},{3},{4},{5},{6}", result.TestName, result.DTOCount, result.SetupTime, result.SerializeTime, result.SerializedByteCount, result.DeserializeTime, result.DLLSize)));

            File.WriteAllText("ALLPCLwLocalProtobuf.csv", columns + data);
        }
    }
}
