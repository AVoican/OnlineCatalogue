using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineCatalogue.Data.Entities
{
    public partial class OnlineCatalogueDbContext : DbContext
    {
        public OnlineCatalogueDbContext()
        {
        }

        public OnlineCatalogueDbContext(DbContextOptions<OnlineCatalogueDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Mark> Marks { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.City).HasMaxLength(128);

                entity.Property(e => e.Street).HasMaxLength(128);
            });

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.HasKey(e => new { e.IdStudent, e.IdSubject });

                entity.ToTable("Mark");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.IdStudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mark_Student");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.IdSubject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mark_Subject");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.FirstName).HasMaxLength(128);

                entity.Property(e => e.LastName).HasMaxLength(128);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.IdAddress)
                    .HasConstraintName("FK_Student_Address");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.IdTeacher)
                    .HasConstraintName("FK_Subject_Teacher");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.IdAddress)
                    .HasConstraintName("FK_Teacher_Address");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
