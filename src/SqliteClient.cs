using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace LiteDB_Benchmark
{
    public sealed class SqliteClient : IClient
    {
        private Context _context;
        private readonly string DatabasePath;

        public SqliteClient()
        {
            DatabasePath = $".\\{Guid.NewGuid()}.db";
            var connectionString = $"Data Source={DatabasePath}";
#if ENABLE_ENCRYPTION
            connectionString += ";Password=123456";
#endif
            _context = new Context(new DbContextOptionsBuilder<Context>().UseSqlite(connectionString).Options);
        }

        public void Dispose()
        {
            _context.Dispose();
            File.Delete(DatabasePath);
        }

        public async Task<TestSubject> FindByIdAsync(Guid id)
        {
            var result = await _context.Set<TestSubject>().SingleOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task InitializeAsync(IEnumerable<TestSubject> seed)
        {
            await _context.Database.EnsureCreatedAsync();
            await _context.AddRangeAsync(seed);
            await _context.SaveChangesAsync();
        }

        public async Task InsertAsync(TestSubject subject)
        {
            await _context.AddAsync(subject);
            await _context.SaveChangesAsync();
        }

        public override string ToString()
        {
#if ENABLE_ENCRYPTION
            return "E-Sqlite";
#else
            return "Sqlite";
#endif
        }

        private class Context : DbContext
        {
            public Context(DbContextOptions options) : base(options)
            {
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<TestSubject>(x => x.HasKey(y => y.Id));
            }
        }
    }
}
