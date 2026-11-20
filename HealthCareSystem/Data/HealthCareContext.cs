using HealthCareSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCareSystem.Data;
public class HealthCareContext : DbContext
{
    public HealthCareContext(DbContextOptions<HealthCareContext> options) : base(options) { }

    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Doctor> Doctors => Set<Doctor>();
    public DbSet<Appointment> Appointments => Set<Appointment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Appointment is the explicit join entity for Patient <-> Doctor.
        modelBuilder.Entity<Appointment>()
            .HasKey(a => new { a.PatientId, a.DoctorId, a.AppointmentDate });

        modelBuilder.Entity<Patient>()
            .HasMany(p => p.Appointments).WithOne(a => a.Patient)
            .HasForeignKey(a => a.PatientId);

        modelBuilder.Entity<Doctor>()
            .HasMany(d => d.Appointments).WithOne(a => a.Doctor)
            .HasForeignKey(a => a.DoctorId);

        modelBuilder.Entity<Doctor>().Property(d => d.Specialization).HasMaxLength(100);
    }
}
