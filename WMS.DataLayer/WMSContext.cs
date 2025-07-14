using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WMS.DataLayer.Configuration;
using WMS.DataLayer.Configurations;
using WMS.Models;

namespace WMS.DataLayer
{
    public class WMSContext : DbContext
    {
        public WMSContext(DbContextOptions<WMSContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .ConfigureWarnings(warnings =>
                    warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CountryConfig());
            builder.ApplyConfiguration(new CompanyConfig());
            builder.ApplyConfiguration(new VendorConfig());
            builder.ApplyConfiguration(new CustomerConfig());
            builder.ApplyConfiguration(new CarrierConfig());
            builder.ApplyConfiguration(new CurrencyConfig());
            builder.ApplyConfiguration(new UomConfig());
            builder.ApplyConfiguration(new ZoneConfig());
            builder.ApplyConfiguration(new UserConfig());
            builder.ApplyConfiguration(new ExceptionLogConfig());
            builder.ApplyConfiguration(new ErrorLogConfig());
            builder.ApplyConfiguration(new SeqErrorLogConfig());
        }

        public DbSet<Country> Country { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Carrier> Carrier { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<Uom> Uom { get; set; }
        public DbSet<Zone> Zone { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<ExceptionLog> ExceptionLog { get; set; }
        public DbSet<ErrorLog> ErrorLog { get; set; }
        public DbSet<SeqErrorLog> SeqErrorLog { get; set; }
    }
}