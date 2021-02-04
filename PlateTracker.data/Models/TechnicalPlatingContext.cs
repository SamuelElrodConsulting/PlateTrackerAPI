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
        public virtual DbSet<Line> Lines { get; set; }
        public virtual DbSet<LineTankType> LineTankTypes { get; set; }
        public virtual DbSet<LineType> LineTypes { get; set; }
        public virtual DbSet<TankMeasurement> TankMeasurements { get; set; }
        public virtual DbSet<TankMeasurementNominal> TankMeasurementNominals { get; set; }
        public virtual DbSet<TankMeasurementType> TankMeasurementTypes { get; set; }
        public virtual DbSet<TankType> TankTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=TechnicalPlating;Trusted_Connection=True;");
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

                entity.Property(e => e.DatetimeCreated)
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

            modelBuilder.Entity<Line>(entity =>
            {
                entity.ToTable("Line");

                entity.HasIndex(e => e.LineId, "IX_Line");

                entity.Property(e => e.LineId).HasColumnName("LineID");

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

                entity.Property(e => e.LineDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LineName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LineTypeId).HasColumnName("LineTypeID");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.HasOne(d => d.LineType)
                    .WithMany(p => p.Lines)
                    .HasForeignKey(d => d.LineTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Line_LineType");
            });

            modelBuilder.Entity<LineTankType>(entity =>
            {
                entity.ToTable("LineTankType");

                entity.Property(e => e.LineTankTypeId).HasColumnName("LineTankTypeID");

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

                entity.Property(e => e.LineId).HasColumnName("LineID");

                entity.Property(e => e.TankTypeId).HasColumnName("TankTypeID");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.HasOne(d => d.Line)
                    .WithMany(p => p.LineTankTypes)
                    .HasForeignKey(d => d.LineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LineTankType_Line");

                entity.HasOne(d => d.TankType)
                    .WithMany(p => p.LineTankTypes)
                    .HasForeignKey(d => d.TankTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LineTankType_LineTankType");
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

                entity.Property(e => e.LineTankTypeId).HasColumnName("LineTankTypeID");

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.TankMeasurementDatetime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TankMeasurementEmployeeId).HasColumnName("TankMeasurementEmployeeID");

                entity.Property(e => e.TankMeasurementTypeId).HasColumnName("TankMeasurementTypeID");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.Value).HasColumnType("decimal(18, 3)");

                entity.HasOne(d => d.LineTankType)
                    .WithMany(p => p.TankMeasurements)
                    .HasForeignKey(d => d.LineTankTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TankMeasurement_LineTankType");

                entity.HasOne(d => d.TankMeasurementEmployee)
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

                entity.HasIndex(e => new { e.TankTypeId, e.TankMeasurementTypeId }, "uq_TankMeasurementNominal")
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

                entity.Property(e => e.TankMeasurementTypeId).HasColumnName("TankMeasurementTypeID");

                entity.Property(e => e.TankTypeId).HasColumnName("TankTypeID");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.HasOne(d => d.TankMeasurementType)
                    .WithMany(p => p.TankMeasurementNominals)
                    .HasForeignKey(d => d.TankMeasurementTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TankMeasurementNominal_TankMeasurementType");

                entity.HasOne(d => d.TankType)
                    .WithMany(p => p.TankMeasurementNominals)
                    .HasForeignKey(d => d.TankTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TankMeasurementNominal_TankMeasurementNominal");
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

            modelBuilder.Entity<TankType>(entity =>
            {
                entity.ToTable("TankType");

                entity.Property(e => e.TankTypeId).HasColumnName("TankTypeID");

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

                entity.Property(e => e.TankTypeDescription)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.TankTypeName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.HasOne(d => d.LineType)
                    .WithMany(p => p.TankTypes)
                    .HasForeignKey(d => d.LineTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TankMeasurementTankType_LineType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
