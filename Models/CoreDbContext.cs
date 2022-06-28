using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ClientInfoAPI.Models
{
    public partial class CoreDbContext : DbContext
    {
        public CoreDbContext()
        {
        }

        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-DFASQ2GB;Database=isdb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.HasIndex(e => e.AccountNumber)
                    .HasName("IX_Account_num")
                    .IsUnique();

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasColumnName("account_number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OutstandingBalance)
                    .HasColumnName("outstanding_balance")
                    .HasColumnType("money");

                entity.Property(e => e.PersonCode).HasColumnName("person_code");

                entity.HasOne(d => d.PersonCodeNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.PersonCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Person");
            });

            modelBuilder.Entity<Persons>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.HasIndex(e => e.IdNumber)
                    .HasName("IX_Person_id")
                    .IsUnique();

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.IdNumber)
                    .IsRequired()
                    .HasColumnName("id_number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasColumnName("surname")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.AccountCode).HasColumnName("account_code");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.CaptureDate)
                    .HasColumnName("capture_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionDate)
                    .HasColumnName("transaction_date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.AccountCodeNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.AccountCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction_Account");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
