using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LiteDB_Benchmark
{
    public sealed class LiteDbClient : IClient
    {
        private readonly string DatabasePath;
        private readonly LiteDatabase _database;
        private readonly ILiteCollection<TestSubject> _testSubjects;

        public LiteDbClient()
        {
            DatabasePath = $".\\{Guid.NewGuid()}.db";
            var connectionString = $"Filename={DatabasePath};connection=shared";
#if ENABLE_ENCRYPTION
            connectionString += ";Password=123456";
#endif
            _database = new LiteDatabase(connectionString);
            _testSubjects = _database.GetCollection<TestSubject>();
            _testSubjects.EnsureIndex(x => x.Id);
        }

        public Task InitializeAsync(IEnumerable<TestSubject> seed)
        {
            _testSubjects.InsertBulk(seed);
            return Task.CompletedTask;
        }

        public Task<TestSubject> FindByIdAsync(Guid id)
        {
            var result = _testSubjects.Find(x => x.Id == id).FirstOrDefault();
            return Task.FromResult(result);
        }

        public Task InsertAsync(TestSubject subject)
        {
            _testSubjects.Insert(subject);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _database.Dispose();
            File.Delete(DatabasePath);
        }

        public override string ToString()
        {
#if ENABLE_ENCRYPTION
            return "E-LiteDb";
#else
            return "LiteDb";
#endif
        }
    }
}
