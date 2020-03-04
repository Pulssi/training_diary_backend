using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace trainingDiaryBackend.Models
{
    public partial class tddbContext : DbContext
    {
        public tddbContext()
        {
        }

        public tddbContext(DbContextOptions<tddbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GymMove> GymMove { get; set; }
        public virtual DbSet<GymSet> GymSet { get; set; }
        public virtual DbSet<Meal> Meal { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Weight> Weight { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GymMove>(entity =>
            {
                entity.HasKey(e => e.IdGymMove)
                    .HasName("PK__GymMove__127ABF0A9AF70158");

                entity.Property(e => e.MoveDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MoveName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GymSet>(entity =>
            {
                entity.HasKey(e => e.IdGymSet)
                    .HasName("PK__GymSet__7CA0CD41285B77DE");

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.HasOne(d => d.IdGymMoveNavigation)
                    .WithMany(p => p.GymSet)
                    .HasForeignKey(d => d.IdGymMove)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GymSet__IdGymMov__76969D2E");

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.GymSet)
                    .HasForeignKey(d => d.IdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GymSet__IdPerson__778AC167");
            });

            modelBuilder.Entity<Meal>(entity =>
            {
                entity.HasKey(e => e.IdMeal)
                    .HasName("PK__Meal__4D7C3B3AF07A767D");

                entity.Property(e => e.MealDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MealName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.Meal)
                    .HasForeignKey(d => d.IdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Meal__IdPerson__7D439ABD");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.IdPerson)
                    .HasName("PK__Person__A5D4E15B3B668184");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Weight>(entity =>
            {
                entity.HasKey(e => e.IdWeight)
                    .HasName("PK__Weight__CEE0A1B62E615389");

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.Weight)
                    .HasForeignKey(d => d.IdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Weight__IdPerson__7A672E12");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
