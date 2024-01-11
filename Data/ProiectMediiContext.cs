using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectMedii.Models;

namespace ProiectMedii.Data
{
    public class ProiectMediiContext : DbContext
    {
        public ProiectMediiContext (DbContextOptions<ProiectMediiContext> options)
            : base(options)
        {
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Patient> Doctors { get; set; }

        public DbSet<ProiectMedii.Models.Appointment> Appointment { get; set; } = default!;
        public DbSet<ProiectMedii.Models.Patient> Patient { get; set; } = default!;
        public DbSet<ProiectMedii.Models.Doctor> Doctor { get; set; } = default!;
        public DbSet<ProiectMedii.Models.PatientFile> PatientFile { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
            .Property(p => p.DateOfBirth)
            .HasColumnType("datetime"); // Adjust the data type based on your database

            // Configure many-to-many relationship between Doctor and Patient through Appointment
            modelBuilder.Entity<Appointment>()
                .HasKey(a => new { a.DoctorId, a.PatientId });

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);

            // Configure one-to-one relationship between Patient and PatientFile
            modelBuilder.Entity<PatientFile>()
                .HasOne(pf => pf.Patient)
                .WithOne(p => p.PatientFile)
                .HasForeignKey<PatientFile>(pf => pf.PatientId);
        }
    }
}
