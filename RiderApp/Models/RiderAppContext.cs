using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace RiderApp.Models
{
    public partial class RiderAppContext : DbContext
    {
        public RiderAppContext()
        {
        }

        public RiderAppContext(DbContextOptions<RiderAppContext> options)
            : base(options)
        {
        }

        public RiderAppContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<Rider> Rider { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=RiderApp;Integrated Security=True");
                IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();  

                string dbstr = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(dbstr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CompletedAt).HasColumnType("datetime");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.ReviewComment)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Rider)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.RiderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Job_Rider");
            });

            modelBuilder.Entity<Rider>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UC_Email")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });
        }
    }
}
