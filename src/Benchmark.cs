using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteDB_Benchmark
{
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [RankColumn(NumeralSystem.Stars)]
    [MemoryDiagnoser]
    public class Benchmark
    {
        public static IEnumerable<IClient> ValuesForAdapter()
        {
            yield return new LiteDbClient();
            yield return new SqliteClient();
        }

        [Params(10, 100, 500, 1000, 10000)]
        public int ItemCount { get; set; }

        private IDictionary<Guid, TestSubject> _data;

        [ParamsSource(nameof(ValuesForAdapter))]
        public IClient Adapter { get; set; }

        [GlobalSetup]
        public async Task Initialize()
        {
            _data = SeedData.GenerateSeedData(ItemCount);
            await this.Adapter.InitializeAsync(_data.Values);
        }

        [GlobalCleanup]
        public void GlobalCleanup()
            => this.Adapter.Dispose();

        [Benchmark]
        public Task<TestSubject> FindByIdAsync()
            => this.Adapter.FindByIdAsync(_data.Keys.First());

        [Benchmark]
        public Task Insert()
            => this.Adapter.InsertAsync(new TestSubject { Id = Guid.NewGuid(), DateTime = DateTime.Now, Integer = 1, String = "something" });
    }
}
