using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LiteDB_Benchmark
{
    internal static class SeedData
    {
        public static Dictionary<Guid, TestSubject> GenerateSeedData(int count)
        {
            var faker = new Faker();
            var random = new Random();
            return Enumerable.Range(0, count)
                .Select(i => new TestSubject
                {
                    DateTime = new DateTime(random.LongRandom(DateTime.Today.Ticks, DateTime.MaxValue.Ticks)),
                    Id = Guid.NewGuid(),
                    Integer = i,
                    String = faker.Random.AlphaNumeric(50)
                })
                .ToDictionary(k => k.Id, v => v);
        }

        static long LongRandom(this Random random, long min, long max)
        {
            byte[] buf = new byte[8];
            random.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            return (Math.Abs(longRand % (max - min)) + min);
        }
    }
}
