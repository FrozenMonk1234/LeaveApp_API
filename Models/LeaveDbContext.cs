using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LeaveApp_API.Models
{
    public partial class LeaveDbContext : DbContext
    {
        public LeaveDbContext()
        {
        }

        public LeaveDbContext(DbContextOptions<LeaveDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Leave> Leave { get; set; }
        public virtual DbSet<TypeOfLeave> TypeOfLeave { get; set; }
        public virtual DbSet<User> User { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=LeaveDb;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Leave>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.Reason)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.Property(e => e.TypeOfLeave)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<TypeOfLeave>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
