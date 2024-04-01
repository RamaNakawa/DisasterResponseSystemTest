using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DisasterResponseSystem.Models
{
    public class DataBaseConext :DbContext
    {
        public DbSet<Donation> Donations { get; set; } = null!;
        public DbSet<AidRequest> AidRequests { get; set; } = null!;
        public DbSet<ProcessingAidRequests> ProcessingAidRequests { get; set; } = null!;

        public DataBaseConext(DbContextOptions<DataBaseConext> options)
       : base(options)
        {
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
