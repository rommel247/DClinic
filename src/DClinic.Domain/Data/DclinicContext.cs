using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DClinic.Domain.Entities;
namespace DClinic.Domain.Data;

public partial class DclinicContext : DbContext
{
    public DclinicContext()
    {
    }

    public DclinicContext(DbContextOptions<DclinicContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientLog> PatientLogs { get; set; }

    public virtual DbSet<Reason> Reasons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DClinicConStr");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>(entity =>
        {
            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.CreatedBy)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Fname)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FName");
            entity.Property(e => e.Lname)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("LName");
            entity.Property(e => e.Mname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("MName");
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<PatientLog>(entity =>
        {
            entity.Property(e => e.Comments).HasMaxLength(500);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            //entity.HasOne(d => d.Patient).WithMany(p => p.PatientLogs)
            //    .HasForeignKey(d => d.PatientId)
            //    .HasConstraintName("FK_PatientLogs_Patients");

            entity.HasOne(d => d.Reason).WithMany(p => p.PatientLogs)
                .HasForeignKey(d => d.ReasonId)
                .HasConstraintName("FK_PatientLogs_Reasons");
        });

        modelBuilder.Entity<Reason>(entity =>
        {
            entity.Property(e => e.ReasonCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReasonDescription).HasMaxLength(500);
            entity.Property(e => e.ReasonShortName).HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
