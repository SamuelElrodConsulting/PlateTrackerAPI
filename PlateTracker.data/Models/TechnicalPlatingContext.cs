using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PlateTracker.data.Models
{
    public partial class TechnicalPlatingContext : DbContext
    {
        public TechnicalPlatingContext()
        {
        }

        public TechnicalPlatingContext(DbContextOptions<TechnicalPlatingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<LineType> LineTypes { get; set; }
        public virtual DbSet<TankMeasurement> TankMeasurements { get; set; }
        public virtual DbSet<TankMeasurementNominal> TankMeasurementNominals { get; set; }
        public virtual DbSet<TankMeasurementTankType> TankMeasurementTankTypes { get; set; }
        public virtual DbSet<TankMeasurementType> TankMeasurementTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer("Server=localhost;Database=TechnicalPlating;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.BuddyPunchId)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("BuddyPunchID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.CreatedDatetime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmployeeFirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeLastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LineType>(entity =>
            {
                entity.ToTable("LineType");

                entity.Property(e => e.LineTypeId).HasColumnName("LineTypeID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.DatetimeCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DatetimeUpdated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LineTypeDescription)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.LineTypeName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");
            });

            modelBuilder.Entity<TankMeasurement>(entity =>
            {
                entity.ToTable("TankMeasurement");

                entity.Property(e => e.TankMeasurementId).HasColumnName("TankMeasurementID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.DatetimeCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DatetimeUpdated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.TankMeasurementDatetime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TankMeasurementEmployeeId).HasColumnName("TankMeasurementEmployeeID");

                entity.Property(e => e.TankMeasurementTankTypeId).HasColumnName("TankMeasurementTankTypeID");

                entity.Property(e => e.TankMeasurementTypeId).HasColumnName("TankMeasurementTypeID");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.Value).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.TankMeasurementTankType)
                    .WithMany(p => p.TankMeasurements)
                    .HasForeignKey(d => d.TankMeasurementTankTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TankMeasurement_TankMeasurementTankType");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TankMeasurements)
                    .HasForeignKey(d => d.TankMeasurementEmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TankMeasurement_Employee");

                entity.HasOne(d => d.TankMeasurementType)
                    .WithMany(p => p.TankMeasurements)
                    .HasForeignKey(d => d.TankMeasurementTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TankMeasurement_TankMeasurementType");
            });

            modelBuilder.Entity<TankMeasurementNominal>(entity =>
            {
                entity.ToTable("TankMeasurementNominal");

                entity.HasIndex(e => new { e.TankMeasurementTankTypeId, e.TankMeasurementTypeId }, "uq_TankMeasurementNominal")
                    .IsUnique();

                entity.Property(e => e.TankMeasurementNominalId).HasColumnName("TankMeasurementNominalID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.DatetimeCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DatetimeUpdated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TankMeasurementTankTypeId).HasColumnName("TankMeasurementTankTypeID");

                entity.Property(e => e.TankMeasurementTypeId).HasColumnName("TankMeasurementTypeID");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.HasOne(d => d.TankMeasurementTankType)
                    .WithMany(p => p.TankMeasurementNominals)
                    .HasForeignKey(d => d.TankMeasurementTankTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TankMeasurementNominal_TankMeasurementNominal");

                entity.HasOne(d => d.TankMeasurementType)
                    .WithMany(p => p.TankMeasurementNominals)
                    .HasForeignKey(d => d.TankMeasurementTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TankMeasurementNominal_TankMeasurementType");
            });

            modelBuilder.Entity<TankMeasurementTankType>(entity =>
            {
                entity.ToTable("TankMeasurementTankType");

                entity.Property(e => e.TankMeasurementTankTypeId).HasColumnName("TankMeasurementTankTypeID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.DatetimeCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DatetimeUpdated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LineTypeId).HasColumnName("LineTypeID");

                entity.Property(e => e.TankMeasurementTankTypeDescription)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.TankMeasurementTankTypeName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.HasOne(d => d.LineType)
                    .WithMany(p => p.TankMeasurementTankTypes)
                    .HasForeignKey(d => d.LineTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TankMeasurementTankType_LineType");
            });

            modelBuilder.Entity<TankMeasurementType>(entity =>
            {
                entity.ToTable("TankMeasurementType");

                entity.Property(e => e.TankMeasurementTypeId).HasColumnName("TankMeasurementTypeID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.DatetimeCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DatetimeUpdated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TankMeasurementTypeDescription)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.TankMeasurementTypeName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Uom)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UOM");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
