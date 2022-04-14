using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace LiteDB_Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmark>();
        }
    }
}
