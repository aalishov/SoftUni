namespace SoftJail.Data
{
    using Microsoft.EntityFrameworkCore;
    using SoftJail.Data.Models;

    public class SoftJailDbContext : DbContext
    {
        public virtual DbSet<Prisoner> Prisoners { get; set; }
        public virtual DbSet<Mail> Mails { get; set; }
        public virtual DbSet<Cell> Cells { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Officer> Officers { get; set; }
        public virtual DbSet<OfficerPrisoner> OfficersPrisoners { get; set; }

        public SoftJailDbContext()
        {
        }

        public SoftJailDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OfficerPrisoner>(entity =>
            {
                entity.HasKey(op => new { op.OfficerId, op.PrisonerId });
            });

            builder.Entity<Prisoner>(entity =>
            {
                entity.HasMany(e => e.PrisonerOfficers)
                .WithOne(op => op.Prisoner)
                .HasForeignKey(e => e.PrisonerId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Prisoner>(entity =>
            {
                entity.Property(p => p.Bail)
                .IsRequired(false);
            });
        }
    }
}