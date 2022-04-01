using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace car_rental_api.Models
{
    public partial class OnlineCarManagementSystemContext : DbContext
    {
        public OnlineCarManagementSystemContext()
        {
        }

        public OnlineCarManagementSystemContext(DbContextOptions<OnlineCarManagementSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<MembershipType> MembershipTypes { get; set; }
        public virtual DbSet<PaymentMode> PaymentModes { get; set; }
        public virtual DbSet<PaymentStatus> PaymentStatuses { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-6F652E0;Database=OnlineCarManagementSystem;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.Bookingid).ValueGeneratedNever();

                entity.Property(e => e.Bookingstatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cars)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CarsId)
                    .HasConstraintName("FK__Bookings__CarsId__01142BA1");

                entity.HasOne(d => d.PaymentMode)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.PaymentModeId)
                    .HasConstraintName("FK__Bookings__Paymen__02FC7413");

                entity.HasOne(d => d.PaymentStatus)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.PaymentStatusId)
                    .HasConstraintName("FK__Bookings__Paymen__03F0984C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Bookings__UserId__02084FDA");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AvailabilityStatus)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CarBrand)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Carstatus)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("carstatus")
                    .HasDefaultValueSql("('Inactive')");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Feedback1)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Feedback");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("FK__Feedback__UsersI__7E37BEF6");
            });

            modelBuilder.Entity<MembershipType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaymentMode>(entity =>
            {
                entity.ToTable("PaymentMode");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaymentStatus>(entity =>
            {
                entity.ToTable("PaymentStatus");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MembershipTypeId).HasColumnName("MembershipTypeID");

                entity.Property(e => e.Membershipstatus)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Inactive')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.MembershipType)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.MembershipTypeId)
                    .HasConstraintName("FK__Users__Membershi__7A672E12");

                entity.HasOne(d => d.RolesNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Roles)
                    .HasConstraintName("FK__Users__Roles__7B5B524B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
