using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Medical_laboratory.Entities;

public partial class _43pBaseForMedicalLaboratoryZelentsovContext : DbContext
{
    public _43pBaseForMedicalLaboratoryZelentsovContext()
    {
    }

    public _43pBaseForMedicalLaboratoryZelentsovContext(DbContextOptions<_43pBaseForMedicalLaboratoryZelentsovContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<History> Histories { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ngknn.ru;Database=43P_BaseForMedicalLaboratoryZelentsov;User ID = 33П; Password = 12357; TrustServerCertificate = true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasOne(d => d.Role).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_Employees_Roles");
        });

        modelBuilder.Entity<History>(entity =>
        {
            entity.ToTable("History");

            entity.Property(e => e.Block).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Result1).HasColumnName("Result");

            entity.HasOne(d => d.Employee).WithMany(p => p.Results)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_Results_Employees");

            entity.HasOne(d => d.Service).WithMany(p => p.Results)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_Results_Services");

            entity.HasOne(d => d.User).WithMany(p => p.Results)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Results_Users");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
