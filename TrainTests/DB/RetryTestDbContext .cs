using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainComponentManagementAPI.TrainManagmentDB;

namespace TrainTests.DB
{
    public class RetryTestDbContext : TrainDbContext
    {
        private int _failCount;
        private readonly int _failLimit;

        public RetryTestDbContext(DbContextOptions<TrainDbContext> options, int failLimit = 2)
            : base(options)
        {
            _failLimit = failLimit;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            if (_failCount < _failLimit)
            {
                _failCount++;
                throw new Exception("Simulated DB failure");
            }

            return Task.FromResult(1); // Simulate success
        }
    }

}