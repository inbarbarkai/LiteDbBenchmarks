using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiteDB_Benchmark
{
    public interface IClient : IDisposable
    {
        Task InitializeAsync(IEnumerable<TestSubject> seed);

        Task InsertAsync(TestSubject subject);

        Task<TestSubject> FindByIdAsync(Guid id);
    }
}
